import { NgModule } from '@angular/core';
import { Route, RouterModule, PreloadAllModules } from '@angular/router';

import { NotFoundComponent } from './pages/not-found/not-found.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { UploadGuardService } from './guards/upload-guard.service';
import { PageType } from './enum';
import { UploadResover } from './resolvers/upload.resolver';

const APP_ROUTES: Route[] = [
    {
        path: '', redirectTo: '/home', pathMatch: 'full'
    },
    {
        path: 'home', loadChildren: './pages/home/home.module#HomeModule',
        data: { needHeaderColor: false, pageType: PageType.PostLogin }
    },
    {
        path: 'guestLink/:guestLinkId', loadChildren: './pages/guest-link-home/guest-link-home.module#GuestLinkHomeModule',
        resolve: {
            uploadResolver: UploadResover
        },
        data: { needHeaderColor: false, pageType: PageType.GuestLink }
    },
    {
        path: 'upload_progress', canActivate: [AuthGuardService, UploadGuardService],
        loadChildren: './pages/upload-progress/upload-progress.module#UploadProgressModule',
        data: { needHeaderColor: false, pageType: PageType.PostLogin }
    },
    // {
    //     path: 'upload_progress/:guestLinkId', canActivate: [AuthGuardService, UploadGuardService],
    //     loadChildren: './pages/upload-progress/upload-progress.module#UploadProgressModule',
    //     resolve: {
    //         uploadResolver: UploadResover
    //     },
    //     data: { needHeaderColor: false, pageType: PageType.GuestLink }
    // },
    {
        path: 'account', loadChildren: './pages/account/account.module#AccountModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'download', loadChildren: './pages/download/download.module#DownloadModule',
        data: { needHeaderColor: false, pageType: PageType.Download}
    },
    {
        path: 'security', loadChildren: './pages/security/security.module#SecurityModule',
        data: { needHeaderColor: true, pageType: PageType.PreLogin }
    },
    {
        path: 'attachmentDetails', loadChildren: './pages/attachment-details/attachment-details.module#AttachmentDetailsModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'filesHistory', loadChildren: './pages/files-history/files-history.module#FilesHistoryModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'addFree', loadChildren: './pages/add-free/add-free.module#AddFreeModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'plan&pricing', loadChildren: './pages/plan-and-pricing/plan-and-pricing.module#PlanAndPricingModule',
        data: { needHeaderColor: true, pageType: PageType.PreLogin }
    },
    {
        path: 'howItWorks', loadChildren: './pages/how-it-works/how-it-works.module#HowItWorksModule',
        data: { needHeaderColor: true, pageType: PageType.PreLogin }
    },
    {
        path: 'benefits', loadChildren: './pages/benefits/benefits.module#BenefitsModule',
        data: { needHeaderColor: true, pageType: PageType.PreLogin }
    },
    {
        path: 'about', loadChildren: './pages/about/about.module#AboutModule',
        data: { needHeaderColor: true, pageType: PageType.PreLogin }
    },
    {
        path: 'features', loadChildren: './pages/features/features.module#FeaturesModule',
        data: { needHeaderColor: true, pageType: PageType.PreLogin }
    },
    {
        path: 'dashboard', loadChildren: './pages/dashboard/dashboard.module#DashboardModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin}
    },
    {
        path: 'settings', loadChildren: './pages/settings/settings.module#SettingsModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'activityLogs', loadChildren: './pages/activity-logs/activity-logs.module#ActivityLogsModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'subUsers', loadChildren: './pages/sub-users/sub-users.module#SubUsersModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: 'guestLinks', loadChildren: './pages/guest-links/guest-links.module#GuestLinksModule',
        data: { needHeaderColor: true, pageType: PageType.PostLogin }
    },
    {
        path: '**', component: NotFoundComponent
    }

];

@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(APP_ROUTES, { preloadingStrategy: PreloadAllModules })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
