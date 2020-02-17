
import { AutoBind } from '../decorators/AutoBind';

export class ContentList {
    publishedButton: HTMLButtonElement;
    publishContentDiv: HTMLDivElement;
    unpublishedButton: HTMLButtonElement;
    unpublishedContentDiv: HTMLDivElement;

    constructor() {
        this.publishedButton = document.getElementById('publishedButton')! as HTMLButtonElement;
        this.publishContentDiv = document.getElementById('published-content')! as HTMLDivElement;
        this.unpublishedButton = document.getElementById('unpublishedButton')! as HTMLButtonElement;
        this.unpublishedContentDiv = document.getElementById('unpublished-content')! as HTMLDivElement;
        this.configure();
    }

    configure() {
        this.publishedButton.addEventListener('click', () =>
        {
            this.showContent(this.publishContentDiv);
            this.hideContent(this.unpublishedContentDiv);
            this.setButtonStateToOn(this.publishedButton);
            this.setButtonStateToOff(this.unpublishedButton);
        }, false);

        this.unpublishedButton.addEventListener('click', () =>
        {
            this.showContent(this.unpublishedContentDiv);
            this.hideContent(this.publishContentDiv);
            this.setButtonStateToOn(this.unpublishedButton);
            this.setButtonStateToOff(this.publishedButton);
        }, false);
    }

    @AutoBind
    private showContent(elem: HTMLDivElement): void {
        elem.classList.contains('hidden') ? elem.classList.remove('hidden') : '';
    }

    @AutoBind
    private hideContent(elem: HTMLDivElement): void {
        elem.classList.contains('hidden') ? '' : elem.classList.add('hidden');
    }

    @AutoBind
    private setButtonStateToOff(button: HTMLButtonElement):void {
        const on = ['bg-orange-700', 'hover:bg-orange-600', 'text-orange-300', 'hover:text-orange-900'];
        const off = ['bg-orange-600', 'hover:bg-orange-700', 'text-orange-500', 'hover:text-orange-300'];

        if (button.classList.contains('bg-orange-700')) {
            button.classList.remove(...on);
            button.classList.add(...off);
        }
    }

    @AutoBind
    private setButtonStateToOn(button: HTMLButtonElement): void {
        const on = ['bg-orange-700', 'hover:bg-orange-600', 'text-orange-300', 'hover:text-orange-900'];
        const off = ['bg-orange-600', 'hover:bg-orange-700', 'text-orange-500', 'hover:text-orange-300'];

        if (button.classList.contains('bg-orange-600')) {
            button.classList.remove(...off);
            button.classList.add(...on);
        }
    }

}