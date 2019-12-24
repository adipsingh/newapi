import { FileType } from './file-type.model';

export interface FilesHistory extends FileType {
    attachmentId: number;
    attachmentType: string;
    attachmentName: string;
    attachmentExpiriedOn: Date;
    attachmentCreationDate: Date;
    attachmentSize: number;
    status: number;
    totalDownload: number;
    attachmentPurgedDate: Date;
}
