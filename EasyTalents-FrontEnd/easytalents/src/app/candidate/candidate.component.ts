import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { WorkingTime } from '../core/models/working-time.model';
import { WorkingTimeService } from '../core/services/working-time.service';
import { BestTimeService } from '../core/services/best-time.service';
import { Knowledge } from '../core/models/knowledge.mode';
import { KnowledgeService } from '../core/services/knowledge.service';
import { Candidate } from '../core/models/candidate.model';
import { BestTime } from '../core/models/best-time.model';
import { CandidateService } from '../core/services/candidate.service';
import { combineLatest, Subject } from 'rxjs';
import { takeUntil, filter, map } from 'rxjs/operators';
import { ActivatedRoute, Router, ResolveStart } from '@angular/router';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss']
})
export class CandidateComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;

  workingTimeList: WorkingTime[] = [];
  bestTimeList: WorkingTime[] = [];
  knowledgesList: Knowledge[] = [];

  candidate: Candidate;

  isNew: boolean = false;
  destroy$: Subject<boolean> = new Subject<boolean>();
  
  constructor(private _formBuilder: FormBuilder,
    private candidateService: CandidateService,
    private workingTimeService: WorkingTimeService,
    private bestTimeService: BestTimeService,
    private knowledgeService: KnowledgeService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
      this.createForms();
     }

  async ngOnInit() {
    this.activatedRoute.params.subscribe(async (params) => {
      let id = params['id'];
      if (id !== null && id !== undefined) {
        this.isNew = false;         
      }
      else {
          this.isNew = true;               
      }
      await this.getLists();
      if (this.isNew === false) {
        this.getCandidateById(id); 
      }
    });            
  }

  get knowledges() {
    return this.thirdFormGroup.get('knowledge') as FormArray;
  }

  get workingTime() {
    return this.secondFormGroup.get('workingTime') as FormArray;
  }

  get bestTime() {
    return this.secondFormGroup.get('bestTime') as FormArray;
  }

  get canSave() {    
    return (this.isNew === true && this.thirdFormGroup.valid) || (this.isNew === false && this.thirdFormGroup.valid) ;
  }

  //

  // public canSave() {
  //   return this.thirdFormGroup;
  // }

  createForms() {
    this.firstFormGroup = this._formBuilder.group({
      emailCtrl: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]]
    });
    this.secondFormGroup = this._formBuilder.group({
      nameCtrl: ['', Validators.required],
      skypeCtrl: ['', Validators.required],
      phoneCtrl: ['', [Validators.required, Validators.pattern("^[0-9]*$"), Validators.minLength(8)]],
      linkedinCtrl: [''],
      cityCtrl: ['', Validators.required],
      stateCtrl: ['', Validators.required],
      portfolioCtrl: [''],
      salaryRequirementsCtrl: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      workingTime: new FormArray([]),
      bestTime: new FormArray([])
    });
    this.thirdFormGroup = this._formBuilder.group({
      knowledge: new FormArray([]),
      extraKnowledgeCtrl: [''],
      crudLinkCtrl: [''],
      crudRatingCtrl: ['', Validators.pattern("(^[0-9]+$|^$)")],
    });
  }

  async getLists() {
    let workingTimeResult = await this.workingTimeService.getList().toPromise();
    
    this.workingTimeList = workingTimeResult.body;

    if (this.isNew === true)
      this.workingTimeList.forEach(x => this.workingTime.push(new FormControl(false)));

    let bestTimeResult = await this.bestTimeService.getList().toPromise();
    
    this.bestTimeList = bestTimeResult.body;

    if (this.isNew === true)
      this.bestTimeList.forEach(x => this.bestTime.push(new FormControl(false)));

    let knowledgeResult = await this.knowledgeService.getList().toPromise();
    
    this.knowledgesList = knowledgeResult.body;

    if (this.isNew === true) {
      this.knowledgesList.forEach(x => this.knowledges.push(this._formBuilder.group({
        id: [x.id, Validators.required],
        description: [x.description, Validators.required],
        rate: ["", Validators.required],
      })));
    }      
  }

  async getCandidateById(id: string) {
    let candidateResult = await this.candidateService.getById(id).toPromise();
    this.candidate = candidateResult.body;

    this.firstFormGroup.get('emailCtrl').patchValue(this.candidate.email);
    this.secondFormGroup.get('nameCtrl').patchValue(this.candidate.name);
    this.secondFormGroup.get('skypeCtrl').patchValue(this.candidate.skype);
    this.secondFormGroup.get('phoneCtrl').patchValue(this.candidate.phone);
    this.secondFormGroup.get('linkedinCtrl').patchValue(this.candidate.linkedin);
    this.secondFormGroup.get('cityCtrl').patchValue(this.candidate.city);
    this.secondFormGroup.get('stateCtrl').patchValue(this.candidate.state);
    this.secondFormGroup.get('portfolioCtrl').patchValue(this.candidate.portfolio);
    this.secondFormGroup.get('salaryRequirementsCtrl').patchValue(this.candidate.salaryRequirements);
    this.thirdFormGroup.get('extraKnowledgeCtrl').patchValue(this.candidate.extraKnowledges);
    this.thirdFormGroup.get('crudLinkCtrl').patchValue(this.candidate.crudUrl);
    this.thirdFormGroup.get('crudRatingCtrl').patchValue(this.candidate.crudRating.toString());
    const workingTimeFormArray = this.workingTime;

    const formControlList = this.workingTimeList.map(element => {
      const selected = this.candidate.workingTimes.find(c => c.id === element.id)
      return new FormControl(selected ? true : false);
    });

    workingTimeFormArray.controls = formControlList;

    const bestTimeFormArray = this.bestTime;

    const bestTimeControlList = this.bestTimeList.map(element => {
      const selected = this.candidate.bestTimes.find(c => c.id === element.id);
      return new FormControl(selected ? true : false);
    });

    bestTimeFormArray.controls = bestTimeControlList;

    const knowledgesFormArray = this.knowledges;

    const knowledgesControlList = this.knowledgesList.map(element => {
      const selected = this.candidate.knowledges.find(c => c.id === element.id)
      return this._formBuilder.group({
        id: [element.id, Validators.required],
        description: [element.description, Validators.required],
        rate: [selected.rate.toString(), Validators.required],
      });      
    });

    knowledgesFormArray.controls = knowledgesControlList;
  }

  save() {
    let firstForm = this.firstFormGroup.getRawValue();
    let secondForm = this.secondFormGroup.getRawValue();
    let thirdForm = this.thirdFormGroup.getRawValue();

    let workingTimes: WorkingTime[] = [];
    let bestTimes: BestTime[] = [];
    let knowledges: Knowledge[] = [];

    this.workingTimeList.forEach((s, i) => {
      if (secondForm.workingTime[i] === true) {
        workingTimes.push({id: s.id});
      }
    });

    this.bestTimeList.forEach((s, i) => {
      if (secondForm.bestTime[i] === true) {
        bestTimes.push({id: s.id});
      }
    });

    knowledges = thirdForm.knowledge.map(item => {return {id: item.id, rate: +item.rate}});
    
    let candidate: Candidate = {      
      email: firstForm.emailCtrl, 
      name: secondForm.nameCtrl, 
      skype: secondForm.skypeCtrl,
      phone: secondForm.phoneCtrl,
      linkedin: secondForm.linkedinCtrl,
      city: secondForm.cityCtrl,
      state: secondForm.stateCtrl,
      portfolio: secondForm.portfolioCtrl,
      salaryRequirements: +secondForm.salaryRequirementsCtrl,
      workingTimes: workingTimes,
      bestTimes: bestTimes,
      knowledges: knowledges,
      extraKnowledges: thirdForm.extraKnowledgeCtrl,
      crudUrl: thirdForm.crudLinkCtrl,
      crudRating: +thirdForm.crudRatingCtrl
    };

    if (this.isNew === true){
      this.candidateService.create(candidate).subscribe(result => this.router.navigateByUrl('/candidate-list'));
    }
    else {
      candidate.id = this.candidate.id;
      this.candidateService.update(candidate).subscribe(result => this.router.navigateByUrl('/candidate-list'));
    }    
  }

}
