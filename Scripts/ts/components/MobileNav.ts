
import { AutoBind } from '../decorators/AutoBind';

export class MobileNav {
    footerNav: HTMLDivElement;
    instructorIcon: HTMLDivElement;
    instructorMenu: HTMLDivElement;
    adminIcon: HTMLDivElement;
    adminMenu: HTMLDivElement;
    showMenu: boolean;

    constructor() {
        this.footerNav = document.getElementById('footer-nav')! as HTMLDivElement;
        this.instructorIcon = document.getElementById('mobile_in_icon')! as HTMLDivElement;
        this.instructorMenu = document.getElementById('mobile_in_menu')! as HTMLDivElement;
        this.adminIcon = document.getElementById('mobile_ad_icon')! as HTMLDivElement;
        this.adminMenu = document.getElementById('mobile_ad_menu')! as HTMLDivElement;
        this.showMenu = false;
        this.configure();
    }

    configure() {
        this.instructorIcon.addEventListener('click', () => {this.showMenuHandler(this.instructorMenu);}, false);
        this.adminIcon.addEventListener('click', () => { this.showMenuHandler(this.adminMenu) }, false);
    }

    @AutoBind
    private showMenuHandler(menu: HTMLDivElement): void {
        this.showMenu = !this.showMenu;
        this.showMenu === true ? menu.classList.remove("hidden") : menu.classList.add("hidden");
    }
}