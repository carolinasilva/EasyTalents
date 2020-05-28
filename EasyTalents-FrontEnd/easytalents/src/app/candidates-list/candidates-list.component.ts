import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CandidateService } from '../core/services/candidate.service';
import { Candidate } from '../core/models/candidate.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-candidates-list',
  templateUrl: './candidates-list.component.html',
  styleUrls: ['./candidates-list.component.scss']
})

export class CandidatesListComponent implements OnInit {

  displayedColumns: string[] = ['name', 'email', 'crudRating', 'actions'];
  dataSource: MatTableDataSource<Candidate>;

  candidateList: Candidate[] = [];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) matSort: MatSort;

  constructor(private router: Router,
    private candidateService: CandidateService,
    public toasterService: ToastrService) {
    
   }

  ngOnInit() {   
    this.getList();    
  }

  getList() {
    this.candidateService.getList().subscribe(result => {
      this.candidateList = result.body;

      if (this.candidateList) {
        this.dataSource = new MatTableDataSource(this.candidateList);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.matSort;
      }      
    });
  }

  addCandidate() {
    this.router.navigateByUrl('/candidate');
  }

  deleteCandidate(id: string) {
    this.candidateService.delete(id).subscribe(result => {
      this.toasterService.success(null, 'Candidate deleted with success', { positionClass: 'toast-bottom-center' });
      this.getList(); 
    });
  }

  editCandidate(id: string) {
    this.router.navigateByUrl('/candidate/' + id);
  }

}
