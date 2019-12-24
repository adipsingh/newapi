export interface Attachment {
    attachmentId: number;
    name: string;
    totalSize: number;
    totalCount: number;
    creationDate: Date;
    expiryDate: Date;
    userId: number;
    accountId: number;
    status: number;
    downloadUrl: string;
    deletionDate: Date;
    guestLinkID?: string;
}
