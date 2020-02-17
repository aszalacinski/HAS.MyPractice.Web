/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Scripts/css/styles.css":
/*!********************************!*\
  !*** ./Scripts/css/styles.css ***!
  \********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

// extracted by mini-css-extract-plugin

/***/ }),

/***/ "./Scripts/ts/App.ts":
/*!***************************!*\
  !*** ./Scripts/ts/App.ts ***!
  \***************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _components_MobileNav__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./components/MobileNav */ "./Scripts/ts/components/MobileNav.ts");
/* harmony import */ var _components_ContentList__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./components/ContentList */ "./Scripts/ts/components/ContentList.ts");


console.log("HAS.MyPractice.Web");
new _components_MobileNav__WEBPACK_IMPORTED_MODULE_0__["MobileNav"]();
new _components_ContentList__WEBPACK_IMPORTED_MODULE_1__["ContentList"]();


/***/ }),

/***/ "./Scripts/ts/components/ContentList.ts":
/*!**********************************************!*\
  !*** ./Scripts/ts/components/ContentList.ts ***!
  \**********************************************/
/*! exports provided: ContentList */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ContentList", function() { return ContentList; });
/* harmony import */ var _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../decorators/AutoBind */ "./Scripts/ts/decorators/AutoBind.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

class ContentList {
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
    _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__["AutoBind"],
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLDivElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "showContent", null);
__decorate([
    _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__["AutoBind"],
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLDivElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "hideContent", null);
__decorate([
    _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__["AutoBind"],
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLButtonElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "setButtonStateToOff", null);
__decorate([
    _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__["AutoBind"],
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLButtonElement]),
    __metadata("design:returntype", void 0)
], ContentList.prototype, "setButtonStateToOn", null);


/***/ }),

/***/ "./Scripts/ts/components/MobileNav.ts":
/*!********************************************!*\
  !*** ./Scripts/ts/components/MobileNav.ts ***!
  \********************************************/
/*! exports provided: MobileNav */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MobileNav", function() { return MobileNav; });
/* harmony import */ var _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../decorators/AutoBind */ "./Scripts/ts/decorators/AutoBind.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

class MobileNav {
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
    _decorators_AutoBind__WEBPACK_IMPORTED_MODULE_0__["AutoBind"],
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [HTMLDivElement]),
    __metadata("design:returntype", void 0)
], MobileNav.prototype, "showMenuHandler", null);


/***/ }),

/***/ "./Scripts/ts/decorators/AutoBind.ts":
/*!*******************************************!*\
  !*** ./Scripts/ts/decorators/AutoBind.ts ***!
  \*******************************************/
/*! exports provided: AutoBind */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AutoBind", function() { return AutoBind; });
function AutoBind(_, __, descriptor) {
    const originalMethod = descriptor.value;
    const adjDescriptor = {
        configurable: true,
        get() {
            const boundFn = originalMethod.bind(this);
            return boundFn;
        }
    };
    return adjDescriptor;
}


/***/ }),

/***/ 0:
/*!**********************************************************!*\
  !*** multi ./Scripts/css/styles.css ./Scripts/ts/App.ts ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

__webpack_require__(/*! ./Scripts/css/styles.css */"./Scripts/css/styles.css");
module.exports = __webpack_require__(/*! ./Scripts/ts/App.ts */"./Scripts/ts/App.ts");


/***/ })

/******/ });
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vLy4vU2NyaXB0cy9jc3Mvc3R5bGVzLmNzcyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL0FwcC50cyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL2NvbXBvbmVudHMvQ29udGVudExpc3QudHMiLCJ3ZWJwYWNrOi8vLy4vU2NyaXB0cy90cy9jb21wb25lbnRzL01vYmlsZU5hdi50cyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL2RlY29yYXRvcnMvQXV0b0JpbmQudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IjtRQUFBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTtRQUNBOzs7UUFHQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0EsMENBQTBDLGdDQUFnQztRQUMxRTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBLHdEQUF3RCxrQkFBa0I7UUFDMUU7UUFDQSxpREFBaUQsY0FBYztRQUMvRDs7UUFFQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0EseUNBQXlDLGlDQUFpQztRQUMxRSxnSEFBZ0gsbUJBQW1CLEVBQUU7UUFDckk7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQSwyQkFBMkIsMEJBQTBCLEVBQUU7UUFDdkQsaUNBQWlDLGVBQWU7UUFDaEQ7UUFDQTtRQUNBOztRQUVBO1FBQ0Esc0RBQXNELCtEQUErRDs7UUFFckg7UUFDQTs7O1FBR0E7UUFDQTs7Ozs7Ozs7Ozs7O0FDbEZBLHVDOzs7Ozs7Ozs7Ozs7QUNBQTtBQUFBO0FBQUE7QUFBbUQ7QUFDSTtBQUV2RCxPQUFPLENBQUMsR0FBRyxDQUFDLG9CQUFvQixDQUFDLENBQUM7QUFFbEMsSUFBSSwrREFBUyxFQUFFLENBQUM7QUFDaEIsSUFBSSxtRUFBVyxFQUFFLENBQUM7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7QUNMZ0M7QUFFM0MsTUFBTSxXQUFXO0lBTXBCO1FBQ0ksSUFBSSxDQUFDLGVBQWUsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLGlCQUFpQixDQUF1QixDQUFDO1FBQ3hGLElBQUksQ0FBQyxpQkFBaUIsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLG1CQUFtQixDQUFvQixDQUFDO1FBQ3pGLElBQUksQ0FBQyxpQkFBaUIsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLG1CQUFtQixDQUF1QixDQUFDO1FBQzVGLElBQUksQ0FBQyxxQkFBcUIsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLHFCQUFxQixDQUFvQixDQUFDO1FBQy9GLElBQUksQ0FBQyxTQUFTLEVBQUUsQ0FBQztJQUNyQixDQUFDO0lBRUQsU0FBUztRQUNMLElBQUksQ0FBQyxlQUFlLENBQUMsZ0JBQWdCLENBQUMsT0FBTyxFQUFFLEdBQUcsRUFBRTtZQUVoRCxJQUFJLENBQUMsV0FBVyxDQUFDLElBQUksQ0FBQyxpQkFBaUIsQ0FBQyxDQUFDO1lBQ3pDLElBQUksQ0FBQyxXQUFXLENBQUMsSUFBSSxDQUFDLHFCQUFxQixDQUFDLENBQUM7WUFDN0MsSUFBSSxDQUFDLGtCQUFrQixDQUFDLElBQUksQ0FBQyxlQUFlLENBQUMsQ0FBQztZQUM5QyxJQUFJLENBQUMsbUJBQW1CLENBQUMsSUFBSSxDQUFDLGlCQUFpQixDQUFDLENBQUM7UUFDckQsQ0FBQyxFQUFFLEtBQUssQ0FBQyxDQUFDO1FBRVYsSUFBSSxDQUFDLGlCQUFpQixDQUFDLGdCQUFnQixDQUFDLE9BQU8sRUFBRSxHQUFHLEVBQUU7WUFFbEQsSUFBSSxDQUFDLFdBQVcsQ0FBQyxJQUFJLENBQUMscUJBQXFCLENBQUMsQ0FBQztZQUM3QyxJQUFJLENBQUMsV0FBVyxDQUFDLElBQUksQ0FBQyxpQkFBaUIsQ0FBQyxDQUFDO1lBQ3pDLElBQUksQ0FBQyxrQkFBa0IsQ0FBQyxJQUFJLENBQUMsaUJBQWlCLENBQUMsQ0FBQztZQUNoRCxJQUFJLENBQUMsbUJBQW1CLENBQUMsSUFBSSxDQUFDLGVBQWUsQ0FBQyxDQUFDO1FBQ25ELENBQUMsRUFBRSxLQUFLLENBQUMsQ0FBQztJQUNkLENBQUM7SUFHTyxXQUFXLENBQUMsSUFBb0I7UUFDcEMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxRQUFRLENBQUMsUUFBUSxDQUFDLENBQUMsQ0FBQyxDQUFDLElBQUksQ0FBQyxTQUFTLENBQUMsTUFBTSxDQUFDLFFBQVEsQ0FBQyxDQUFDLENBQUMsQ0FBQyxFQUFFLENBQUM7SUFDN0UsQ0FBQztJQUdPLFdBQVcsQ0FBQyxJQUFvQjtRQUNwQyxJQUFJLENBQUMsU0FBUyxDQUFDLFFBQVEsQ0FBQyxRQUFRLENBQUMsQ0FBQyxDQUFDLENBQUMsRUFBRSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsU0FBUyxDQUFDLEdBQUcsQ0FBQyxRQUFRLENBQUMsQ0FBQztJQUMxRSxDQUFDO0lBR08sbUJBQW1CLENBQUMsTUFBeUI7UUFDakQsTUFBTSxFQUFFLEdBQUcsQ0FBQyxlQUFlLEVBQUUscUJBQXFCLEVBQUUsaUJBQWlCLEVBQUUsdUJBQXVCLENBQUMsQ0FBQztRQUNoRyxNQUFNLEdBQUcsR0FBRyxDQUFDLGVBQWUsRUFBRSxxQkFBcUIsRUFBRSxpQkFBaUIsRUFBRSx1QkFBdUIsQ0FBQyxDQUFDO1FBRWpHLElBQUksTUFBTSxDQUFDLFNBQVMsQ0FBQyxRQUFRLENBQUMsZUFBZSxDQUFDLEVBQUU7WUFDNUMsTUFBTSxDQUFDLFNBQVMsQ0FBQyxNQUFNLENBQUMsR0FBRyxFQUFFLENBQUMsQ0FBQztZQUMvQixNQUFNLENBQUMsU0FBUyxDQUFDLEdBQUcsQ0FBQyxHQUFHLEdBQUcsQ0FBQyxDQUFDO1NBQ2hDO0lBQ0wsQ0FBQztJQUdPLGtCQUFrQixDQUFDLE1BQXlCO1FBQ2hELE1BQU0sRUFBRSxHQUFHLENBQUMsZUFBZSxFQUFFLHFCQUFxQixFQUFFLGlCQUFpQixFQUFFLHVCQUF1QixDQUFDLENBQUM7UUFDaEcsTUFBTSxHQUFHLEdBQUcsQ0FBQyxlQUFlLEVBQUUscUJBQXFCLEVBQUUsaUJBQWlCLEVBQUUsdUJBQXVCLENBQUMsQ0FBQztRQUVqRyxJQUFJLE1BQU0sQ0FBQyxTQUFTLENBQUMsUUFBUSxDQUFDLGVBQWUsQ0FBQyxFQUFFO1lBQzVDLE1BQU0sQ0FBQyxTQUFTLENBQUMsTUFBTSxDQUFDLEdBQUcsR0FBRyxDQUFDLENBQUM7WUFDaEMsTUFBTSxDQUFDLFNBQVMsQ0FBQyxHQUFHLENBQUMsR0FBRyxFQUFFLENBQUMsQ0FBQztTQUMvQjtJQUNMLENBQUM7Q0FFSjtBQS9CRztJQURDLDZEQUFROztxQ0FDaUIsY0FBYzs7OENBRXZDO0FBR0Q7SUFEQyw2REFBUTs7cUNBQ2lCLGNBQWM7OzhDQUV2QztBQUdEO0lBREMsNkRBQVE7O3FDQUMyQixpQkFBaUI7O3NEQVFwRDtBQUdEO0lBREMsNkRBQVE7O3FDQUMwQixpQkFBaUI7O3FEQVFuRDs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQ2hFNkM7QUFFM0MsTUFBTSxTQUFTO0lBUWxCO1FBQ0ksSUFBSSxDQUFDLFNBQVMsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLFlBQVksQ0FBb0IsQ0FBQztRQUMxRSxJQUFJLENBQUMsY0FBYyxHQUFHLFFBQVEsQ0FBQyxjQUFjLENBQUMsZ0JBQWdCLENBQW9CLENBQUM7UUFDbkYsSUFBSSxDQUFDLGNBQWMsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLGdCQUFnQixDQUFvQixDQUFDO1FBQ25GLElBQUksQ0FBQyxTQUFTLEdBQUcsUUFBUSxDQUFDLGNBQWMsQ0FBQyxnQkFBZ0IsQ0FBb0IsQ0FBQztRQUM5RSxJQUFJLENBQUMsU0FBUyxHQUFHLFFBQVEsQ0FBQyxjQUFjLENBQUMsZ0JBQWdCLENBQW9CLENBQUM7UUFDOUUsSUFBSSxDQUFDLFFBQVEsR0FBRyxLQUFLLENBQUM7UUFDdEIsSUFBSSxDQUFDLFNBQVMsRUFBRSxDQUFDO0lBQ3JCLENBQUM7SUFFRCxTQUFTO1FBQ0wsSUFBSSxDQUFDLGNBQWMsQ0FBQyxnQkFBZ0IsQ0FBQyxPQUFPLEVBQUUsR0FBRyxFQUFFLEdBQUUsSUFBSSxDQUFDLGVBQWUsQ0FBQyxJQUFJLENBQUMsY0FBYyxDQUFDLENBQUMsRUFBQyxFQUFFLEtBQUssQ0FBQyxDQUFDO1FBQ3pHLElBQUksQ0FBQyxTQUFTLENBQUMsZ0JBQWdCLENBQUMsT0FBTyxFQUFFLEdBQUcsRUFBRSxHQUFHLElBQUksQ0FBQyxlQUFlLENBQUMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxFQUFDLENBQUMsRUFBRSxLQUFLLENBQUMsQ0FBQztJQUNwRyxDQUFDO0lBR08sZUFBZSxDQUFDLElBQW9CO1FBQ3hDLElBQUksQ0FBQyxRQUFRLEdBQUcsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFDO1FBQy9CLElBQUksQ0FBQyxRQUFRLEtBQUssSUFBSSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsU0FBUyxDQUFDLE1BQU0sQ0FBQyxRQUFRLENBQUMsQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxHQUFHLENBQUMsUUFBUSxDQUFDLENBQUM7SUFDNUYsQ0FBQztDQUNKO0FBSkc7SUFEQyw2REFBUTs7cUNBQ3FCLGNBQWM7O2dEQUczQzs7Ozs7Ozs7Ozs7OztBQzdCTDtBQUFBO0FBQU8sU0FBUyxRQUFRLENBQUMsQ0FBTSxFQUFFLEVBQVUsRUFBRSxVQUE4QjtJQUN2RSxNQUFNLGNBQWMsR0FBRyxVQUFVLENBQUMsS0FBSyxDQUFDO0lBQ3hDLE1BQU0sYUFBYSxHQUF1QjtRQUN0QyxZQUFZLEVBQUUsSUFBSTtRQUNsQixHQUFHO1lBQ0MsTUFBTSxPQUFPLEdBQUcsY0FBYyxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsQ0FBQztZQUMxQyxPQUFPLE9BQU8sQ0FBQztRQUNuQixDQUFDO0tBQ0osQ0FBQztJQUNGLE9BQU8sYUFBYSxDQUFDO0FBQ3pCLENBQUMiLCJmaWxlIjoic2l0ZS5qcyIsInNvdXJjZXNDb250ZW50IjpbIiBcdC8vIFRoZSBtb2R1bGUgY2FjaGVcbiBcdHZhciBpbnN0YWxsZWRNb2R1bGVzID0ge307XG5cbiBcdC8vIFRoZSByZXF1aXJlIGZ1bmN0aW9uXG4gXHRmdW5jdGlvbiBfX3dlYnBhY2tfcmVxdWlyZV9fKG1vZHVsZUlkKSB7XG5cbiBcdFx0Ly8gQ2hlY2sgaWYgbW9kdWxlIGlzIGluIGNhY2hlXG4gXHRcdGlmKGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdKSB7XG4gXHRcdFx0cmV0dXJuIGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdLmV4cG9ydHM7XG4gXHRcdH1cbiBcdFx0Ly8gQ3JlYXRlIGEgbmV3IG1vZHVsZSAoYW5kIHB1dCBpdCBpbnRvIHRoZSBjYWNoZSlcbiBcdFx0dmFyIG1vZHVsZSA9IGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdID0ge1xuIFx0XHRcdGk6IG1vZHVsZUlkLFxuIFx0XHRcdGw6IGZhbHNlLFxuIFx0XHRcdGV4cG9ydHM6IHt9XG4gXHRcdH07XG5cbiBcdFx0Ly8gRXhlY3V0ZSB0aGUgbW9kdWxlIGZ1bmN0aW9uXG4gXHRcdG1vZHVsZXNbbW9kdWxlSWRdLmNhbGwobW9kdWxlLmV4cG9ydHMsIG1vZHVsZSwgbW9kdWxlLmV4cG9ydHMsIF9fd2VicGFja19yZXF1aXJlX18pO1xuXG4gXHRcdC8vIEZsYWcgdGhlIG1vZHVsZSBhcyBsb2FkZWRcbiBcdFx0bW9kdWxlLmwgPSB0cnVlO1xuXG4gXHRcdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG4gXHRcdHJldHVybiBtb2R1bGUuZXhwb3J0cztcbiBcdH1cblxuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZXMgb2JqZWN0IChfX3dlYnBhY2tfbW9kdWxlc19fKVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5tID0gbW9kdWxlcztcblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGUgY2FjaGVcbiBcdF9fd2VicGFja19yZXF1aXJlX18uYyA9IGluc3RhbGxlZE1vZHVsZXM7XG5cbiBcdC8vIGRlZmluZSBnZXR0ZXIgZnVuY3Rpb24gZm9yIGhhcm1vbnkgZXhwb3J0c1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5kID0gZnVuY3Rpb24oZXhwb3J0cywgbmFtZSwgZ2V0dGVyKSB7XG4gXHRcdGlmKCFfX3dlYnBhY2tfcmVxdWlyZV9fLm8oZXhwb3J0cywgbmFtZSkpIHtcbiBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgbmFtZSwgeyBlbnVtZXJhYmxlOiB0cnVlLCBnZXQ6IGdldHRlciB9KTtcbiBcdFx0fVxuIFx0fTtcblxuIFx0Ly8gZGVmaW5lIF9fZXNNb2R1bGUgb24gZXhwb3J0c1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5yID0gZnVuY3Rpb24oZXhwb3J0cykge1xuIFx0XHRpZih0eXBlb2YgU3ltYm9sICE9PSAndW5kZWZpbmVkJyAmJiBTeW1ib2wudG9TdHJpbmdUYWcpIHtcbiBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgU3ltYm9sLnRvU3RyaW5nVGFnLCB7IHZhbHVlOiAnTW9kdWxlJyB9KTtcbiBcdFx0fVxuIFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgJ19fZXNNb2R1bGUnLCB7IHZhbHVlOiB0cnVlIH0pO1xuIFx0fTtcblxuIFx0Ly8gY3JlYXRlIGEgZmFrZSBuYW1lc3BhY2Ugb2JqZWN0XG4gXHQvLyBtb2RlICYgMTogdmFsdWUgaXMgYSBtb2R1bGUgaWQsIHJlcXVpcmUgaXRcbiBcdC8vIG1vZGUgJiAyOiBtZXJnZSBhbGwgcHJvcGVydGllcyBvZiB2YWx1ZSBpbnRvIHRoZSBuc1xuIFx0Ly8gbW9kZSAmIDQ6IHJldHVybiB2YWx1ZSB3aGVuIGFscmVhZHkgbnMgb2JqZWN0XG4gXHQvLyBtb2RlICYgOHwxOiBiZWhhdmUgbGlrZSByZXF1aXJlXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnQgPSBmdW5jdGlvbih2YWx1ZSwgbW9kZSkge1xuIFx0XHRpZihtb2RlICYgMSkgdmFsdWUgPSBfX3dlYnBhY2tfcmVxdWlyZV9fKHZhbHVlKTtcbiBcdFx0aWYobW9kZSAmIDgpIHJldHVybiB2YWx1ZTtcbiBcdFx0aWYoKG1vZGUgJiA0KSAmJiB0eXBlb2YgdmFsdWUgPT09ICdvYmplY3QnICYmIHZhbHVlICYmIHZhbHVlLl9fZXNNb2R1bGUpIHJldHVybiB2YWx1ZTtcbiBcdFx0dmFyIG5zID0gT2JqZWN0LmNyZWF0ZShudWxsKTtcbiBcdFx0X193ZWJwYWNrX3JlcXVpcmVfXy5yKG5zKTtcbiBcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KG5zLCAnZGVmYXVsdCcsIHsgZW51bWVyYWJsZTogdHJ1ZSwgdmFsdWU6IHZhbHVlIH0pO1xuIFx0XHRpZihtb2RlICYgMiAmJiB0eXBlb2YgdmFsdWUgIT0gJ3N0cmluZycpIGZvcih2YXIga2V5IGluIHZhbHVlKSBfX3dlYnBhY2tfcmVxdWlyZV9fLmQobnMsIGtleSwgZnVuY3Rpb24oa2V5KSB7IHJldHVybiB2YWx1ZVtrZXldOyB9LmJpbmQobnVsbCwga2V5KSk7XG4gXHRcdHJldHVybiBucztcbiBcdH07XG5cbiBcdC8vIGdldERlZmF1bHRFeHBvcnQgZnVuY3Rpb24gZm9yIGNvbXBhdGliaWxpdHkgd2l0aCBub24taGFybW9ueSBtb2R1bGVzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm4gPSBmdW5jdGlvbihtb2R1bGUpIHtcbiBcdFx0dmFyIGdldHRlciA9IG1vZHVsZSAmJiBtb2R1bGUuX19lc01vZHVsZSA/XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0RGVmYXVsdCgpIHsgcmV0dXJuIG1vZHVsZVsnZGVmYXVsdCddOyB9IDpcbiBcdFx0XHRmdW5jdGlvbiBnZXRNb2R1bGVFeHBvcnRzKCkgeyByZXR1cm4gbW9kdWxlOyB9O1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQoZ2V0dGVyLCAnYScsIGdldHRlcik7XG4gXHRcdHJldHVybiBnZXR0ZXI7XG4gXHR9O1xuXG4gXHQvLyBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGxcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubyA9IGZ1bmN0aW9uKG9iamVjdCwgcHJvcGVydHkpIHsgcmV0dXJuIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbChvYmplY3QsIHByb3BlcnR5KTsgfTtcblxuIFx0Ly8gX193ZWJwYWNrX3B1YmxpY19wYXRoX19cbiBcdF9fd2VicGFja19yZXF1aXJlX18ucCA9IFwiXCI7XG5cblxuIFx0Ly8gTG9hZCBlbnRyeSBtb2R1bGUgYW5kIHJldHVybiBleHBvcnRzXG4gXHRyZXR1cm4gX193ZWJwYWNrX3JlcXVpcmVfXyhfX3dlYnBhY2tfcmVxdWlyZV9fLnMgPSAwKTtcbiIsIi8vIGV4dHJhY3RlZCBieSBtaW5pLWNzcy1leHRyYWN0LXBsdWdpbiIsImltcG9ydCB7IE1vYmlsZU5hdiB9IGZyb20gXCIuL2NvbXBvbmVudHMvTW9iaWxlTmF2XCI7XHJcbmltcG9ydCB7IENvbnRlbnRMaXN0IH0gZnJvbSBcIi4vY29tcG9uZW50cy9Db250ZW50TGlzdFwiO1xyXG5cclxuY29uc29sZS5sb2coXCJIQVMuTXlQcmFjdGljZS5XZWJcIik7XHJcblxyXG5uZXcgTW9iaWxlTmF2KCk7XHJcbm5ldyBDb250ZW50TGlzdCgpOyIsIlxyXG5pbXBvcnQgeyBBdXRvQmluZCB9IGZyb20gJy4uL2RlY29yYXRvcnMvQXV0b0JpbmQnO1xyXG5cclxuZXhwb3J0IGNsYXNzIENvbnRlbnRMaXN0IHtcclxuICAgIHB1Ymxpc2hlZEJ1dHRvbjogSFRNTEJ1dHRvbkVsZW1lbnQ7XHJcbiAgICBwdWJsaXNoQ29udGVudERpdjogSFRNTERpdkVsZW1lbnQ7XHJcbiAgICB1bnB1Ymxpc2hlZEJ1dHRvbjogSFRNTEJ1dHRvbkVsZW1lbnQ7XHJcbiAgICB1bnB1Ymxpc2hlZENvbnRlbnREaXY6IEhUTUxEaXZFbGVtZW50O1xyXG5cclxuICAgIGNvbnN0cnVjdG9yKCkge1xyXG4gICAgICAgIHRoaXMucHVibGlzaGVkQnV0dG9uID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ3B1Ymxpc2hlZEJ1dHRvbicpISBhcyBIVE1MQnV0dG9uRWxlbWVudDtcclxuICAgICAgICB0aGlzLnB1Ymxpc2hDb250ZW50RGl2ID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ3B1Ymxpc2hlZC1jb250ZW50JykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMudW5wdWJsaXNoZWRCdXR0b24gPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgndW5wdWJsaXNoZWRCdXR0b24nKSEgYXMgSFRNTEJ1dHRvbkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy51bnB1Ymxpc2hlZENvbnRlbnREaXYgPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgndW5wdWJsaXNoZWQtY29udGVudCcpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLmNvbmZpZ3VyZSgpO1xyXG4gICAgfVxyXG5cclxuICAgIGNvbmZpZ3VyZSgpIHtcclxuICAgICAgICB0aGlzLnB1Ymxpc2hlZEJ1dHRvbi5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsICgpID0+XHJcbiAgICAgICAge1xyXG4gICAgICAgICAgICB0aGlzLnNob3dDb250ZW50KHRoaXMucHVibGlzaENvbnRlbnREaXYpO1xyXG4gICAgICAgICAgICB0aGlzLmhpZGVDb250ZW50KHRoaXMudW5wdWJsaXNoZWRDb250ZW50RGl2KTtcclxuICAgICAgICAgICAgdGhpcy5zZXRCdXR0b25TdGF0ZVRvT24odGhpcy5wdWJsaXNoZWRCdXR0b24pO1xyXG4gICAgICAgICAgICB0aGlzLnNldEJ1dHRvblN0YXRlVG9PZmYodGhpcy51bnB1Ymxpc2hlZEJ1dHRvbik7XHJcbiAgICAgICAgfSwgZmFsc2UpO1xyXG5cclxuICAgICAgICB0aGlzLnVucHVibGlzaGVkQnV0dG9uLmFkZEV2ZW50TGlzdGVuZXIoJ2NsaWNrJywgKCkgPT5cclxuICAgICAgICB7XHJcbiAgICAgICAgICAgIHRoaXMuc2hvd0NvbnRlbnQodGhpcy51bnB1Ymxpc2hlZENvbnRlbnREaXYpO1xyXG4gICAgICAgICAgICB0aGlzLmhpZGVDb250ZW50KHRoaXMucHVibGlzaENvbnRlbnREaXYpO1xyXG4gICAgICAgICAgICB0aGlzLnNldEJ1dHRvblN0YXRlVG9Pbih0aGlzLnVucHVibGlzaGVkQnV0dG9uKTtcclxuICAgICAgICAgICAgdGhpcy5zZXRCdXR0b25TdGF0ZVRvT2ZmKHRoaXMucHVibGlzaGVkQnV0dG9uKTtcclxuICAgICAgICB9LCBmYWxzZSk7XHJcbiAgICB9XHJcblxyXG4gICAgQEF1dG9CaW5kXHJcbiAgICBwcml2YXRlIHNob3dDb250ZW50KGVsZW06IEhUTUxEaXZFbGVtZW50KTogdm9pZCB7XHJcbiAgICAgICAgZWxlbS5jbGFzc0xpc3QuY29udGFpbnMoJ2hpZGRlbicpID8gZWxlbS5jbGFzc0xpc3QucmVtb3ZlKCdoaWRkZW4nKSA6ICcnO1xyXG4gICAgfVxyXG5cclxuICAgIEBBdXRvQmluZFxyXG4gICAgcHJpdmF0ZSBoaWRlQ29udGVudChlbGVtOiBIVE1MRGl2RWxlbWVudCk6IHZvaWQge1xyXG4gICAgICAgIGVsZW0uY2xhc3NMaXN0LmNvbnRhaW5zKCdoaWRkZW4nKSA/ICcnIDogZWxlbS5jbGFzc0xpc3QuYWRkKCdoaWRkZW4nKTtcclxuICAgIH1cclxuXHJcbiAgICBAQXV0b0JpbmRcclxuICAgIHByaXZhdGUgc2V0QnV0dG9uU3RhdGVUb09mZihidXR0b246IEhUTUxCdXR0b25FbGVtZW50KTp2b2lkIHtcclxuICAgICAgICBjb25zdCBvbiA9IFsnYmctb3JhbmdlLTcwMCcsICdob3ZlcjpiZy1vcmFuZ2UtNjAwJywgJ3RleHQtb3JhbmdlLTMwMCcsICdob3Zlcjp0ZXh0LW9yYW5nZS05MDAnXTtcclxuICAgICAgICBjb25zdCBvZmYgPSBbJ2JnLW9yYW5nZS02MDAnLCAnaG92ZXI6Ymctb3JhbmdlLTcwMCcsICd0ZXh0LW9yYW5nZS01MDAnLCAnaG92ZXI6dGV4dC1vcmFuZ2UtMzAwJ107XHJcblxyXG4gICAgICAgIGlmIChidXR0b24uY2xhc3NMaXN0LmNvbnRhaW5zKCdiZy1vcmFuZ2UtNzAwJykpIHtcclxuICAgICAgICAgICAgYnV0dG9uLmNsYXNzTGlzdC5yZW1vdmUoLi4ub24pO1xyXG4gICAgICAgICAgICBidXR0b24uY2xhc3NMaXN0LmFkZCguLi5vZmYpO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbiAgICBAQXV0b0JpbmRcclxuICAgIHByaXZhdGUgc2V0QnV0dG9uU3RhdGVUb09uKGJ1dHRvbjogSFRNTEJ1dHRvbkVsZW1lbnQpOiB2b2lkIHtcclxuICAgICAgICBjb25zdCBvbiA9IFsnYmctb3JhbmdlLTcwMCcsICdob3ZlcjpiZy1vcmFuZ2UtNjAwJywgJ3RleHQtb3JhbmdlLTMwMCcsICdob3Zlcjp0ZXh0LW9yYW5nZS05MDAnXTtcclxuICAgICAgICBjb25zdCBvZmYgPSBbJ2JnLW9yYW5nZS02MDAnLCAnaG92ZXI6Ymctb3JhbmdlLTcwMCcsICd0ZXh0LW9yYW5nZS01MDAnLCAnaG92ZXI6dGV4dC1vcmFuZ2UtMzAwJ107XHJcblxyXG4gICAgICAgIGlmIChidXR0b24uY2xhc3NMaXN0LmNvbnRhaW5zKCdiZy1vcmFuZ2UtNjAwJykpIHtcclxuICAgICAgICAgICAgYnV0dG9uLmNsYXNzTGlzdC5yZW1vdmUoLi4ub2ZmKTtcclxuICAgICAgICAgICAgYnV0dG9uLmNsYXNzTGlzdC5hZGQoLi4ub24pO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbn0iLCJcclxuaW1wb3J0IHsgQXV0b0JpbmQgfSBmcm9tICcuLi9kZWNvcmF0b3JzL0F1dG9CaW5kJztcclxuXHJcbmV4cG9ydCBjbGFzcyBNb2JpbGVOYXYge1xyXG4gICAgZm9vdGVyTmF2OiBIVE1MRGl2RWxlbWVudDtcclxuICAgIGluc3RydWN0b3JJY29uOiBIVE1MRGl2RWxlbWVudDtcclxuICAgIGluc3RydWN0b3JNZW51OiBIVE1MRGl2RWxlbWVudDtcclxuICAgIGFkbWluSWNvbjogSFRNTERpdkVsZW1lbnQ7XHJcbiAgICBhZG1pbk1lbnU6IEhUTUxEaXZFbGVtZW50O1xyXG4gICAgc2hvd01lbnU6IGJvb2xlYW47XHJcblxyXG4gICAgY29uc3RydWN0b3IoKSB7XHJcbiAgICAgICAgdGhpcy5mb290ZXJOYXYgPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnZm9vdGVyLW5hdicpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLmluc3RydWN0b3JJY29uID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ21vYmlsZV9pbl9pY29uJykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuaW5zdHJ1Y3Rvck1lbnUgPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnbW9iaWxlX2luX21lbnUnKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5hZG1pbkljb24gPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnbW9iaWxlX2FkX2ljb24nKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5hZG1pbk1lbnUgPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnbW9iaWxlX2FkX21lbnUnKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5zaG93TWVudSA9IGZhbHNlO1xyXG4gICAgICAgIHRoaXMuY29uZmlndXJlKCk7XHJcbiAgICB9XHJcblxyXG4gICAgY29uZmlndXJlKCkge1xyXG4gICAgICAgIHRoaXMuaW5zdHJ1Y3Rvckljb24uYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoKSA9PiB7dGhpcy5zaG93TWVudUhhbmRsZXIodGhpcy5pbnN0cnVjdG9yTWVudSk7fSwgZmFsc2UpO1xyXG4gICAgICAgIHRoaXMuYWRtaW5JY29uLmFkZEV2ZW50TGlzdGVuZXIoJ2NsaWNrJywgKCkgPT4geyB0aGlzLnNob3dNZW51SGFuZGxlcih0aGlzLmFkbWluTWVudSkgfSwgZmFsc2UpO1xyXG4gICAgfVxyXG5cclxuICAgIEBBdXRvQmluZFxyXG4gICAgcHJpdmF0ZSBzaG93TWVudUhhbmRsZXIobWVudTogSFRNTERpdkVsZW1lbnQpOiB2b2lkIHtcclxuICAgICAgICB0aGlzLnNob3dNZW51ID0gIXRoaXMuc2hvd01lbnU7XHJcbiAgICAgICAgdGhpcy5zaG93TWVudSA9PT0gdHJ1ZSA/IG1lbnUuY2xhc3NMaXN0LnJlbW92ZShcImhpZGRlblwiKSA6IG1lbnUuY2xhc3NMaXN0LmFkZChcImhpZGRlblwiKTtcclxuICAgIH1cclxufSIsIi8vIGF1dG9iaW5kIGRlY29yYXRvclxyXG5leHBvcnQgZnVuY3Rpb24gQXV0b0JpbmQoXzogYW55LCBfXzogc3RyaW5nLCBkZXNjcmlwdG9yOiBQcm9wZXJ0eURlc2NyaXB0b3IpIHtcclxuICAgIGNvbnN0IG9yaWdpbmFsTWV0aG9kID0gZGVzY3JpcHRvci52YWx1ZTtcclxuICAgIGNvbnN0IGFkakRlc2NyaXB0b3I6IFByb3BlcnR5RGVzY3JpcHRvciA9IHtcclxuICAgICAgICBjb25maWd1cmFibGU6IHRydWUsXHJcbiAgICAgICAgZ2V0KCkge1xyXG4gICAgICAgICAgICBjb25zdCBib3VuZEZuID0gb3JpZ2luYWxNZXRob2QuYmluZCh0aGlzKTtcclxuICAgICAgICAgICAgcmV0dXJuIGJvdW5kRm47XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuICAgIHJldHVybiBhZGpEZXNjcmlwdG9yO1xyXG59Il0sInNvdXJjZVJvb3QiOiIifQ==