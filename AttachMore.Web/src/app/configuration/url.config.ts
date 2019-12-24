import { environment } from '../../environments/environment';

export const URLS = {
    login: `${environment.apiBaseUrl}login`,
    register: `${environment.apiBaseUrl}register`,
    uploadFile: `${environment.apiBaseUrl}File`,
    attachment: `${environment.apiBaseUrl}Attachments`,
    downloadAttachment: `${environment.apiBaseUrl}Attachments/DownloadAttachments`,
    attachmentPreview: `${environment.apiBaseUrl}Attachments/PreviewAttachments`,
    expirySettings: `${environment.apiBaseUrl}AttachmentExpirySettings`,
    securitySettings: `${environment.apiBaseUrl}AttachmentSecuritySettings`,
    notificationSettings: `${environment.apiBaseUrl}AttachmentNotificationSettings`,
    verifyEmail: `${environment.apiBaseUrl}Account`,
    securitySettingsInfo: `${environment.apiBaseUrl}AttachmentSecuritySettings/GetSecuritySettings`,
    changePassword: `${environment.apiBaseUrl}Account/ChangePassword`,
    resetPassword: `${environment.apiBaseUrl}Account/ResetPassword`,
    forgetPassword: `${environment.apiBaseUrl}Account/ForgotPassword`,
    dashboard: `${environment.apiBaseUrl}dashboard/Stats`,
    filesHistory: `${environment.apiBaseUrl}dashboard/History`,
    attachmentDetails: `${environment.apiBaseUrl}dashboard/FilesDetail`,
    userDetail: `${environment.apiBaseUrl}Dashboard/UserDetail`,
    dataUsage: `${environment.apiBaseUrl}Dashboard/DataUsage`,
    updateAttachmentName: `${environment.apiBaseUrl}Attachments/EditAttachmentName`,
    allPackages: `${environment.apiBaseUrl}Package/GetAll`,
    buyPackage: `${environment.apiBaseUrl}Package`,
    guestLink: `${environment.apiBaseUrl}GuestLink`
};
