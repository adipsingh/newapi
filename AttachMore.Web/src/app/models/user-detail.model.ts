import { UserStatus } from '../enum';

export interface UserDetail {
    expires: string;
    name: string;
    nextBillingDate: Date;
    status: UserStatus;
}
