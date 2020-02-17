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
export class ContentList {
    constructor() {
        this.publishedButton = document.getElementById('publishedButton');
        this.publishContentDiv = document.getElementById('published-content');
        this.unpublishedButton = document.getElementById('unpublishedButton');
        this.unpublishedContentDiv = document.getElementById('unpublished-content');
        this.configure();
    }
    configure() {
        this.publishedButton.addEventListener('click', () => {
            this.showContent(this.publishContentDiv);
            this.hideContent(this.unpublishedContentDiv);
            this.setButtonStateToOn(this.publishedButton);
            this.setButtonStateToOff(this.unpublishedButton);
        }, false);
        this.unpublishedButton.addEventListener('click', () => {
            this.showContent(this.unpublishedContentDiv);
            this.hideContent(this.publishContentDiv);
            this.setButtonStateToOn(this.unpublishedButton);
            this.setButtonStateToOff(this.publishedButton);
        }, false);
    }
    showContent(elem) {
        elem.classList.contains('hidden') ? elem.classList.remove('hidden') : '';
    }
    hideContent(elem) {
        elem.classList.contains('hidden') ? '' : elem.classList.add('hidden');
    }
    setButtonStateToOff(button) {
        const on = ['bg-orange-700', 'hover:bg-orange-600', 'text-orange-300', 'hover:text-orange-900'];
        const off = ['bg-orange-600', 'hover:bg-orange-700', 'text-orange-500', 'hover:text-orange-300'];
        if (button.classList.contains('bg-orange-700')) {
            button.classList.remove(...on);
            button.classList.add(...off);
        }
    }
    setButtonStateToOn(button) {
        const on = ['bg-orange-700', 'hover:bg-orange-600', 'text-orange-300', 'hover:text-orange-900'];
        const off = ['bg-orange-600', 'hover:bg-orange-700', 'text-orange-500', 'hover:text-orange-300'];
        if (button.classList.contains('bg-orange-600')) {
            button.classList.remove(...off);
            button.classList.add(...on);
        }
    }
}
__decorate([
    AutoBind,
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLDivElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "showContent", null);
__decorate([
    AutoBind,
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLDivElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "hideContent", null);
__decorate([
    AutoBind,
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLButtonElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "setButtonStateToOff", null);
__decorate([
    AutoBind,
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLButtonElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "setButtonStateToOn", null);
//# sourceMappingURL=ContentList.js.map