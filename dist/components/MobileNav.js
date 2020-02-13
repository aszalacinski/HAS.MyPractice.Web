var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { AutoBind } from '../decorators/AutoBind';
export class MobileNav {
    constructor() {
        this.footerNav = document.getElementById('footer-nav');
        this.instructorIcon = document.getElementById('mobile_in_icon');
        this.instructorMenu = document.getElementById('mobile_in_menu');
        this.adminIcon = document.getElementById('mobile_ad_icon');
        this.adminMenu = document.getElementById('mobile_ad_menu');
        this.showMenu = false;
        this.configure();
    }
    configure() {
        this.instructorIcon.addEventListener('click', () => { this.showMenuHandler(this.instructorMenu); }, false);
        this.adminIcon.addEventListener('click', () => { this.showMenuHandler(this.adminMenu); }, false);
    }
    showMenuHandler(menu) {
        this.showMenu = !this.showMenu;
        this.showMenu === true ? menu.classList.remove("hidden") : menu.classList.add("hidden");
    }
}
__decorate([
    AutoBind,
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLDivElement]),
    __metadata("design:returntype", void 0)
], MobileNav.prototype, "showMenuHandler", null);
//# sourceMappingURL=MobileNav.js.map