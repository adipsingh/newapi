import { PageType } from '../enum';
import { AuthDialogService } from '../services/auth-dialog.service';

interface NavigationModel {
    name: string;
    children?: NavigationModel[];
    icon?: string;
    route?: string;
    authorizeuser?: boolean;
    action?: void;
    href?: string;
    pageType?: PageType;
}
export class HeaderNavigationConfig {
    constructor(private authDialogService: AuthDialogService) {

    }

    navigations: NavigationModel[] = [{
        name: 'Learn More',
        pageType: PageType.PreLogin,
        children: [{
            name: 'How it Works',
            route: 'howItWorks',
            href: 'javascript:void(0)'
        }, {
            name: 'Features',
            route: 'Features',
            href: 'javascript:void(0)'
        }, {
            name: 'Benefits',
            route: 'benefits',
            href: 'javascript:void(0)'
        }, {
            name: 'Security',
            route: 'security',
            href: 'javascript:void(0)'
        }, {
            name: 'The Difference',
            href: 'thedifference.html'
        }, {
            name: 'Customer Reviews',
            href: 'reviews.html'
        }, {
            name: 'About Attachmore',
            href: '/about'
        }]
    }, {
        name: 'Pricing',
        href: 'javascript:void(0)',
        pageType: PageType.PreLogin,
        children: [{
            name: 'Pricing',
            route: 'plan&pricing',
            href: 'javascript:void(0)'
        }, {
            name: 'FAQs',
            href: 'faqs.html'
        }, {
            name: 'Ad Free Pledge',
            href: '/addFree'
        }]
    }, {
        name: 'Support',
        href: 'javascript:void(0)',
        pageType: PageType.PreLogin,
        children: [{
            name: 'Support Home',
            href: 'support.html'
        }, {
            name: 'How to Download Files',
            href: 'howtodownloadfiles.html'
        }, {
            name: 'Update Billing Info',
            href: 'https://atmo.re/Customers/EditAccountBillingInformation.aspx'
        }, {
            name: 'Speed Test',
            href: 'speedtest.html://atmo.re/Customers/EditAccountBillingInformation.aspx'
        }]
    }, {
        name: 'SignIn | SignOut',
        children: [{
            name: 'Support Home',
            href: 'support.html',
            action: this.authDialogService.openSigninForm()
        }, {
            name: 'How to Download Files',
            href: 'howtodownloadfiles.html'
        }, {
            name: 'Update Billing Info',
            href: 'https://atmo.re/Customers/EditAccountBillingInformation.aspx'
        }, {
            name: 'Speed Test',
            href: 'speedtest.html://atmo.re/Customers/EditAccountBillingInformation.aspx'
        }]
    }];
}
