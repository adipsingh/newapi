import { FileDetail } from './file-detail.model';
import { FileType } from '.';

export interface AttachmentDetails extends FileType {
    name: string;
    accessCompany: string;
    accessContectNumber: string;
    accessEmail: string;
    accessName: string;
    accessPassword: string;
    accessPayment: number;
    attachmentId: number;
    byEmail: boolean;
    byText: boolean;
    createdOn: Date;
    deleteAfter: Date;
    downloadLimit: number;
    expiredOn: Date;
    payments: number;
    purgedOn: Date;
    totalDownload: number;
    totalFileInAttachment: number;
    uploadedBy: string;
    whenDownload: boolean;
    whenExpired: boolean;
    attachmentSize: number;
    downloadURL: string;
    status: number;
    filesDetail: FileDetail[];
}
