export interface GuestLink {
    guestLinkID: number;
    userId: number;
    linkName: string;
    linkUrl: string;
    uploadLimit: number;
    guestId: number;
    creationDate: Date;
    status: number;
    expirySettings: GuestLinkExpirySettings;
    notifySettings: GuestLinkNotifySettings;
    securitySettings: GuestLinkSecuritySettings;
}

export interface GuestLinkExpirySettings {
    id: number;
    gustLinkId: number;
    uploadLimit: number;
    numberOfUses: number;
    expirationDate: Date;
    creationDate: Date;
}
export interface GuestLinkNotifySettings {
    id: number;
    gustLinkId: number;
    onDownloaded: boolean;
    onExpired: boolean;
    byEmail: boolean;
    byText: boolean
    creationDate: Date;
}

export interface GuestLinkSecuritySettings {
    id: number;
    gustLinkId: number;
    email: boolean;
    company: boolean;
    name: boolean;
    phone: boolean;
    password: boolean;
    passwordProtectedPage: boolean;
    creationDate: Date;
}

