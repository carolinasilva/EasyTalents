import { WorkingTime } from './working-time.model';
import { BestTime } from './best-time.model';
import { Knowledge } from './knowledge.mode';

export interface Candidate {
    id?: string;
    email: string;
    name: string;
    skype: string;
    phone: string;
    linkedin: string;
    city: string;
    state: string;
    portfolio: string;
    salaryRequirements: number;
    extraKnowledges: string;
    crudUrl: string;
    crudRating: number | null;
    workingTimes: WorkingTime[];
    bestTimes: BestTime[];
    knowledges: Knowledge[];
}