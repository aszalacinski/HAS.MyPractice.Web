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
        if (this.instructorIcon != null && this.instructorMenu != null) {
            this.instructorIcon.addEventListener('click', () => { this.showMenuHandler(this.instructorMenu); }, false);
        }
        if (this.adminIcon != null && this.adminMenu != null) {
            this.adminIcon.addEventListener('click', () => { this.showMenuHandler(this.adminMenu); }, false);
        }
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
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vLy4vU2NyaXB0cy9jc3Mvc3R5bGVzLmNzcyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL0FwcC50cyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL2NvbXBvbmVudHMvQ29udGVudExpc3QudHMiLCJ3ZWJwYWNrOi8vLy4vU2NyaXB0cy90cy9jb21wb25lbnRzL01vYmlsZU5hdi50cyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL2RlY29yYXRvcnMvQXV0b0JpbmQudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IjtRQUFBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTtRQUNBOzs7UUFHQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0EsMENBQTBDLGdDQUFnQztRQUMxRTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBLHdEQUF3RCxrQkFBa0I7UUFDMUU7UUFDQSxpREFBaUQsY0FBYztRQUMvRDs7UUFFQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0EseUNBQXlDLGlDQUFpQztRQUMxRSxnSEFBZ0gsbUJBQW1CLEVBQUU7UUFDckk7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQSwyQkFBMkIsMEJBQTBCLEVBQUU7UUFDdkQsaUNBQWlDLGVBQWU7UUFDaEQ7UUFDQTtRQUNBOztRQUVBO1FBQ0Esc0RBQXNELCtEQUErRDs7UUFFckg7UUFDQTs7O1FBR0E7UUFDQTs7Ozs7Ozs7Ozs7O0FDbEZBLHVDOzs7Ozs7Ozs7Ozs7QUNBQTtBQUFBO0FBQUE7QUFBbUQ7QUFDSTtBQUV2RCxPQUFPLENBQUMsR0FBRyxDQUFDLG9CQUFvQixDQUFDLENBQUM7QUFFbEMsSUFBSSwrREFBUyxFQUFFLENBQUM7QUFDaEIsSUFBSSxtRUFBVyxFQUFFLENBQUM7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7QUNMZ0M7QUFFM0MsTUFBTSxXQUFXO0lBTXBCO1FBQ0ksSUFBSSxDQUFDLGVBQWUsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLGlCQUFpQixDQUF1QixDQUFDO1FBQ3hGLElBQUksQ0FBQyxpQkFBaUIsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLG1CQUFtQixDQUFvQixDQUFDO1FBQ3pGLElBQUksQ0FBQyxpQkFBaUIsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLG1CQUFtQixDQUF1QixDQUFDO1FBQzVGLElBQUksQ0FBQyxxQkFBcUIsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLHFCQUFxQixDQUFvQixDQUFDO1FBQy9GLElBQUksQ0FBQyxTQUFTLEVBQUUsQ0FBQztJQUNyQixDQUFDO0lBRUQsU0FBUztRQUNMLElBQUksQ0FBQyxlQUFlLENBQUMsZ0JBQWdCLENBQUMsT0FBTyxFQUFFLEdBQUcsRUFBRTtZQUVoRCxJQUFJLENBQUMsV0FBVyxDQUFDLElBQUksQ0FBQyxpQkFBaUIsQ0FBQyxDQUFDO1lBQ3pDLElBQUksQ0FBQyxXQUFXLENBQUMsSUFBSSxDQUFDLHFCQUFxQixDQUFDLENBQUM7WUFDN0MsSUFBSSxDQUFDLGtCQUFrQixDQUFDLElBQUksQ0FBQyxlQUFlLENBQUMsQ0FBQztZQUM5QyxJQUFJLENBQUMsbUJBQW1CLENBQUMsSUFBSSxDQUFDLGlCQUFpQixDQUFDLENBQUM7UUFDckQsQ0FBQyxFQUFFLEtBQUssQ0FBQyxDQUFDO1FBRVYsSUFBSSxDQUFDLGlCQUFpQixDQUFDLGdCQUFnQixDQUFDLE9BQU8sRUFBRSxHQUFHLEVBQUU7WUFFbEQsSUFBSSxDQUFDLFdBQVcsQ0FBQyxJQUFJLENBQUMscUJBQXFCLENBQUMsQ0FBQztZQUM3QyxJQUFJLENBQUMsV0FBVyxDQUFDLElBQUksQ0FBQyxpQkFBaUIsQ0FBQyxDQUFDO1lBQ3pDLElBQUksQ0FBQyxrQkFBa0IsQ0FBQyxJQUFJLENBQUMsaUJBQWlCLENBQUMsQ0FBQztZQUNoRCxJQUFJLENBQUMsbUJBQW1CLENBQUMsSUFBSSxDQUFDLGVBQWUsQ0FBQyxDQUFDO1FBQ25ELENBQUMsRUFBRSxLQUFLLENBQUMsQ0FBQztJQUNkLENBQUM7SUFHTyxXQUFXLENBQUMsSUFBb0I7UUFDcEMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxRQUFRLENBQUMsUUFBUSxDQUFDLENBQUMsQ0FBQyxDQUFDLElBQUksQ0FBQyxTQUFTLENBQUMsTUFBTSxDQUFDLFFBQVEsQ0FBQyxDQUFDLENBQUMsQ0FBQyxFQUFFLENBQUM7SUFDN0UsQ0FBQztJQUdPLFdBQVcsQ0FBQyxJQUFvQjtRQUNwQyxJQUFJLENBQUMsU0FBUyxDQUFDLFFBQVEsQ0FBQyxRQUFRLENBQUMsQ0FBQyxDQUFDLENBQUMsRUFBRSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsU0FBUyxDQUFDLEdBQUcsQ0FBQyxRQUFRLENBQUMsQ0FBQztJQUMxRSxDQUFDO0lBR08sbUJBQW1CLENBQUMsTUFBeUI7UUFDakQsTUFBTSxFQUFFLEdBQUcsQ0FBQyxlQUFlLEVBQUUscUJBQXFCLEVBQUUsaUJBQWlCLEVBQUUsdUJBQXVCLENBQUMsQ0FBQztRQUNoRyxNQUFNLEdBQUcsR0FBRyxDQUFDLGVBQWUsRUFBRSxxQkFBcUIsRUFBRSxpQkFBaUIsRUFBRSx1QkFBdUIsQ0FBQyxDQUFDO1FBRWpHLElBQUksTUFBTSxDQUFDLFNBQVMsQ0FBQyxRQUFRLENBQUMsZUFBZSxDQUFDLEVBQUU7WUFDNUMsTUFBTSxDQUFDLFNBQVMsQ0FBQyxNQUFNLENBQUMsR0FBRyxFQUFFLENBQUMsQ0FBQztZQUMvQixNQUFNLENBQUMsU0FBUyxDQUFDLEdBQUcsQ0FBQyxHQUFHLEdBQUcsQ0FBQyxDQUFDO1NBQ2hDO0lBQ0wsQ0FBQztJQUdPLGtCQUFrQixDQUFDLE1BQXlCO1FBQ2hELE1BQU0sRUFBRSxHQUFHLENBQUMsZUFBZSxFQUFFLHFCQUFxQixFQUFFLGlCQUFpQixFQUFFLHVCQUF1QixDQUFDLENBQUM7UUFDaEcsTUFBTSxHQUFHLEdBQUcsQ0FBQyxlQUFlLEVBQUUscUJBQXFCLEVBQUUsaUJBQWlCLEVBQUUsdUJBQXVCLENBQUMsQ0FBQztRQUVqRyxJQUFJLE1BQU0sQ0FBQyxTQUFTLENBQUMsUUFBUSxDQUFDLGVBQWUsQ0FBQyxFQUFFO1lBQzVDLE1BQU0sQ0FBQyxTQUFTLENBQUMsTUFBTSxDQUFDLEdBQUcsR0FBRyxDQUFDLENBQUM7WUFDaEMsTUFBTSxDQUFDLFNBQVMsQ0FBQyxHQUFHLENBQUMsR0FBRyxFQUFFLENBQUMsQ0FBQztTQUMvQjtJQUNMLENBQUM7Q0FFSjtBQS9CRztJQURDLDZEQUFROztxQ0FDaUIsY0FBYzs7OENBRXZDO0FBR0Q7SUFEQyw2REFBUTs7cUNBQ2lCLGNBQWM7OzhDQUV2QztBQUdEO0lBREMsNkRBQVE7O3FDQUMyQixpQkFBaUI7O3NEQVFwRDtBQUdEO0lBREMsNkRBQVE7O3FDQUMwQixpQkFBaUI7O3FEQVFuRDs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQ2hFNkM7QUFFM0MsTUFBTSxTQUFTO0lBUWxCO1FBQ0ksSUFBSSxDQUFDLFNBQVMsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLFlBQVksQ0FBb0IsQ0FBQztRQUMxRSxJQUFJLENBQUMsY0FBYyxHQUFHLFFBQVEsQ0FBQyxjQUFjLENBQUMsZ0JBQWdCLENBQW9CLENBQUM7UUFDbkYsSUFBSSxDQUFDLGNBQWMsR0FBRyxRQUFRLENBQUMsY0FBYyxDQUFDLGdCQUFnQixDQUFvQixDQUFDO1FBQ25GLElBQUksQ0FBQyxTQUFTLEdBQUcsUUFBUSxDQUFDLGNBQWMsQ0FBQyxnQkFBZ0IsQ0FBb0IsQ0FBQztRQUM5RSxJQUFJLENBQUMsU0FBUyxHQUFHLFFBQVEsQ0FBQyxjQUFjLENBQUMsZ0JBQWdCLENBQW9CLENBQUM7UUFDOUUsSUFBSSxDQUFDLFFBQVEsR0FBRyxLQUFLLENBQUM7UUFDdEIsSUFBSSxDQUFDLFNBQVMsRUFBRSxDQUFDO0lBQ3JCLENBQUM7SUFFRCxTQUFTO1FBQ0wsSUFBSSxJQUFJLENBQUMsY0FBYyxJQUFJLElBQUksSUFBSSxJQUFJLENBQUMsY0FBYyxJQUFJLElBQUksRUFBRTtZQUM1RCxJQUFJLENBQUMsY0FBYyxDQUFDLGdCQUFnQixDQUFDLE9BQU8sRUFBRSxHQUFHLEVBQUUsR0FBRyxJQUFJLENBQUMsZUFBZSxDQUFDLElBQUksQ0FBQyxjQUFjLENBQUMsQ0FBQyxDQUFDLENBQUMsRUFBRSxLQUFLLENBQUMsQ0FBQztTQUM5RztRQUVELElBQUksSUFBSSxDQUFDLFNBQVMsSUFBSSxJQUFJLElBQUksSUFBSSxDQUFDLFNBQVMsSUFBSSxJQUFJLEVBQUU7WUFDbEQsSUFBSSxDQUFDLFNBQVMsQ0FBQyxnQkFBZ0IsQ0FBQyxPQUFPLEVBQUUsR0FBRyxFQUFFLEdBQUcsSUFBSSxDQUFDLGVBQWUsQ0FBQyxJQUFJLENBQUMsU0FBUyxDQUFDLEVBQUMsQ0FBQyxFQUFFLEtBQUssQ0FBQyxDQUFDO1NBQ25HO0lBQ0wsQ0FBQztJQUdPLGVBQWUsQ0FBQyxJQUFvQjtRQUN4QyxJQUFJLENBQUMsUUFBUSxHQUFHLENBQUMsSUFBSSxDQUFDLFFBQVEsQ0FBQztRQUMvQixJQUFJLENBQUMsUUFBUSxLQUFLLElBQUksQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxNQUFNLENBQUMsUUFBUSxDQUFDLENBQUMsQ0FBQyxDQUFDLElBQUksQ0FBQyxTQUFTLENBQUMsR0FBRyxDQUFDLFFBQVEsQ0FBQyxDQUFDO0lBQzVGLENBQUM7Q0FDSjtBQUpHO0lBREMsNkRBQVE7O3FDQUNxQixjQUFjOztnREFHM0M7Ozs7Ozs7Ozs7Ozs7QUNsQ0w7QUFBQTtBQUFPLFNBQVMsUUFBUSxDQUFDLENBQU0sRUFBRSxFQUFVLEVBQUUsVUFBOEI7SUFDdkUsTUFBTSxjQUFjLEdBQUcsVUFBVSxDQUFDLEtBQUssQ0FBQztJQUN4QyxNQUFNLGFBQWEsR0FBdUI7UUFDdEMsWUFBWSxFQUFFLElBQUk7UUFDbEIsR0FBRztZQUNDLE1BQU0sT0FBTyxHQUFHLGNBQWMsQ0FBQyxJQUFJLENBQUMsSUFBSSxDQUFDLENBQUM7WUFDMUMsT0FBTyxPQUFPLENBQUM7UUFDbkIsQ0FBQztLQUNKLENBQUM7SUFDRixPQUFPLGFBQWEsQ0FBQztBQUN6QixDQUFDIiwiZmlsZSI6InNpdGUuanMiLCJzb3VyY2VzQ29udGVudCI6WyIgXHQvLyBUaGUgbW9kdWxlIGNhY2hlXG4gXHR2YXIgaW5zdGFsbGVkTW9kdWxlcyA9IHt9O1xuXG4gXHQvLyBUaGUgcmVxdWlyZSBmdW5jdGlvblxuIFx0ZnVuY3Rpb24gX193ZWJwYWNrX3JlcXVpcmVfXyhtb2R1bGVJZCkge1xuXG4gXHRcdC8vIENoZWNrIGlmIG1vZHVsZSBpcyBpbiBjYWNoZVxuIFx0XHRpZihpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSkge1xuIFx0XHRcdHJldHVybiBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXS5leHBvcnRzO1xuIFx0XHR9XG4gXHRcdC8vIENyZWF0ZSBhIG5ldyBtb2R1bGUgKGFuZCBwdXQgaXQgaW50byB0aGUgY2FjaGUpXG4gXHRcdHZhciBtb2R1bGUgPSBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSA9IHtcbiBcdFx0XHRpOiBtb2R1bGVJZCxcbiBcdFx0XHRsOiBmYWxzZSxcbiBcdFx0XHRleHBvcnRzOiB7fVxuIFx0XHR9O1xuXG4gXHRcdC8vIEV4ZWN1dGUgdGhlIG1vZHVsZSBmdW5jdGlvblxuIFx0XHRtb2R1bGVzW21vZHVsZUlkXS5jYWxsKG1vZHVsZS5leHBvcnRzLCBtb2R1bGUsIG1vZHVsZS5leHBvcnRzLCBfX3dlYnBhY2tfcmVxdWlyZV9fKTtcblxuIFx0XHQvLyBGbGFnIHRoZSBtb2R1bGUgYXMgbG9hZGVkXG4gXHRcdG1vZHVsZS5sID0gdHJ1ZTtcblxuIFx0XHQvLyBSZXR1cm4gdGhlIGV4cG9ydHMgb2YgdGhlIG1vZHVsZVxuIFx0XHRyZXR1cm4gbW9kdWxlLmV4cG9ydHM7XG4gXHR9XG5cblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGVzIG9iamVjdCAoX193ZWJwYWNrX21vZHVsZXNfXylcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubSA9IG1vZHVsZXM7XG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlIGNhY2hlXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmMgPSBpbnN0YWxsZWRNb2R1bGVzO1xuXG4gXHQvLyBkZWZpbmUgZ2V0dGVyIGZ1bmN0aW9uIGZvciBoYXJtb255IGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uZCA9IGZ1bmN0aW9uKGV4cG9ydHMsIG5hbWUsIGdldHRlcikge1xuIFx0XHRpZighX193ZWJwYWNrX3JlcXVpcmVfXy5vKGV4cG9ydHMsIG5hbWUpKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIG5hbWUsIHsgZW51bWVyYWJsZTogdHJ1ZSwgZ2V0OiBnZXR0ZXIgfSk7XG4gXHRcdH1cbiBcdH07XG5cbiBcdC8vIGRlZmluZSBfX2VzTW9kdWxlIG9uIGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uciA9IGZ1bmN0aW9uKGV4cG9ydHMpIHtcbiBcdFx0aWYodHlwZW9mIFN5bWJvbCAhPT0gJ3VuZGVmaW5lZCcgJiYgU3ltYm9sLnRvU3RyaW5nVGFnKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFN5bWJvbC50b1N0cmluZ1RhZywgeyB2YWx1ZTogJ01vZHVsZScgfSk7XG4gXHRcdH1cbiBcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsICdfX2VzTW9kdWxlJywgeyB2YWx1ZTogdHJ1ZSB9KTtcbiBcdH07XG5cbiBcdC8vIGNyZWF0ZSBhIGZha2UgbmFtZXNwYWNlIG9iamVjdFxuIFx0Ly8gbW9kZSAmIDE6IHZhbHVlIGlzIGEgbW9kdWxlIGlkLCByZXF1aXJlIGl0XG4gXHQvLyBtb2RlICYgMjogbWVyZ2UgYWxsIHByb3BlcnRpZXMgb2YgdmFsdWUgaW50byB0aGUgbnNcbiBcdC8vIG1vZGUgJiA0OiByZXR1cm4gdmFsdWUgd2hlbiBhbHJlYWR5IG5zIG9iamVjdFxuIFx0Ly8gbW9kZSAmIDh8MTogYmVoYXZlIGxpa2UgcmVxdWlyZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy50ID0gZnVuY3Rpb24odmFsdWUsIG1vZGUpIHtcbiBcdFx0aWYobW9kZSAmIDEpIHZhbHVlID0gX193ZWJwYWNrX3JlcXVpcmVfXyh2YWx1ZSk7XG4gXHRcdGlmKG1vZGUgJiA4KSByZXR1cm4gdmFsdWU7XG4gXHRcdGlmKChtb2RlICYgNCkgJiYgdHlwZW9mIHZhbHVlID09PSAnb2JqZWN0JyAmJiB2YWx1ZSAmJiB2YWx1ZS5fX2VzTW9kdWxlKSByZXR1cm4gdmFsdWU7XG4gXHRcdHZhciBucyA9IE9iamVjdC5jcmVhdGUobnVsbCk7XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18ucihucyk7XG4gXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShucywgJ2RlZmF1bHQnLCB7IGVudW1lcmFibGU6IHRydWUsIHZhbHVlOiB2YWx1ZSB9KTtcbiBcdFx0aWYobW9kZSAmIDIgJiYgdHlwZW9mIHZhbHVlICE9ICdzdHJpbmcnKSBmb3IodmFyIGtleSBpbiB2YWx1ZSkgX193ZWJwYWNrX3JlcXVpcmVfXy5kKG5zLCBrZXksIGZ1bmN0aW9uKGtleSkgeyByZXR1cm4gdmFsdWVba2V5XTsgfS5iaW5kKG51bGwsIGtleSkpO1xuIFx0XHRyZXR1cm4gbnM7XG4gXHR9O1xuXG4gXHQvLyBnZXREZWZhdWx0RXhwb3J0IGZ1bmN0aW9uIGZvciBjb21wYXRpYmlsaXR5IHdpdGggbm9uLWhhcm1vbnkgbW9kdWxlc1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5uID0gZnVuY3Rpb24obW9kdWxlKSB7XG4gXHRcdHZhciBnZXR0ZXIgPSBtb2R1bGUgJiYgbW9kdWxlLl9fZXNNb2R1bGUgP1xuIFx0XHRcdGZ1bmN0aW9uIGdldERlZmF1bHQoKSB7IHJldHVybiBtb2R1bGVbJ2RlZmF1bHQnXTsgfSA6XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0TW9kdWxlRXhwb3J0cygpIHsgcmV0dXJuIG1vZHVsZTsgfTtcbiBcdFx0X193ZWJwYWNrX3JlcXVpcmVfXy5kKGdldHRlciwgJ2EnLCBnZXR0ZXIpO1xuIFx0XHRyZXR1cm4gZ2V0dGVyO1xuIFx0fTtcblxuIFx0Ly8gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm8gPSBmdW5jdGlvbihvYmplY3QsIHByb3BlcnR5KSB7IHJldHVybiBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGwob2JqZWN0LCBwcm9wZXJ0eSk7IH07XG5cbiBcdC8vIF9fd2VicGFja19wdWJsaWNfcGF0aF9fXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnAgPSBcIlwiO1xuXG5cbiBcdC8vIExvYWQgZW50cnkgbW9kdWxlIGFuZCByZXR1cm4gZXhwb3J0c1xuIFx0cmV0dXJuIF9fd2VicGFja19yZXF1aXJlX18oX193ZWJwYWNrX3JlcXVpcmVfXy5zID0gMCk7XG4iLCIvLyBleHRyYWN0ZWQgYnkgbWluaS1jc3MtZXh0cmFjdC1wbHVnaW4iLCJpbXBvcnQgeyBNb2JpbGVOYXYgfSBmcm9tIFwiLi9jb21wb25lbnRzL01vYmlsZU5hdlwiO1xyXG5pbXBvcnQgeyBDb250ZW50TGlzdCB9IGZyb20gXCIuL2NvbXBvbmVudHMvQ29udGVudExpc3RcIjtcclxuXHJcbmNvbnNvbGUubG9nKFwiSEFTLk15UHJhY3RpY2UuV2ViXCIpO1xyXG5cclxubmV3IE1vYmlsZU5hdigpO1xyXG5uZXcgQ29udGVudExpc3QoKTsiLCJcclxuaW1wb3J0IHsgQXV0b0JpbmQgfSBmcm9tICcuLi9kZWNvcmF0b3JzL0F1dG9CaW5kJztcclxuXHJcbmV4cG9ydCBjbGFzcyBDb250ZW50TGlzdCB7XHJcbiAgICBwdWJsaXNoZWRCdXR0b246IEhUTUxCdXR0b25FbGVtZW50O1xyXG4gICAgcHVibGlzaENvbnRlbnREaXY6IEhUTUxEaXZFbGVtZW50O1xyXG4gICAgdW5wdWJsaXNoZWRCdXR0b246IEhUTUxCdXR0b25FbGVtZW50O1xyXG4gICAgdW5wdWJsaXNoZWRDb250ZW50RGl2OiBIVE1MRGl2RWxlbWVudDtcclxuXHJcbiAgICBjb25zdHJ1Y3RvcigpIHtcclxuICAgICAgICB0aGlzLnB1Ymxpc2hlZEJ1dHRvbiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdwdWJsaXNoZWRCdXR0b24nKSEgYXMgSFRNTEJ1dHRvbkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5wdWJsaXNoQ29udGVudERpdiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdwdWJsaXNoZWQtY29udGVudCcpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLnVucHVibGlzaGVkQnV0dG9uID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ3VucHVibGlzaGVkQnV0dG9uJykhIGFzIEhUTUxCdXR0b25FbGVtZW50O1xyXG4gICAgICAgIHRoaXMudW5wdWJsaXNoZWRDb250ZW50RGl2ID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ3VucHVibGlzaGVkLWNvbnRlbnQnKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5jb25maWd1cmUoKTtcclxuICAgIH1cclxuXHJcbiAgICBjb25maWd1cmUoKSB7XHJcbiAgICAgICAgdGhpcy5wdWJsaXNoZWRCdXR0b24uYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoKSA9PlxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgdGhpcy5zaG93Q29udGVudCh0aGlzLnB1Ymxpc2hDb250ZW50RGl2KTtcclxuICAgICAgICAgICAgdGhpcy5oaWRlQ29udGVudCh0aGlzLnVucHVibGlzaGVkQ29udGVudERpdik7XHJcbiAgICAgICAgICAgIHRoaXMuc2V0QnV0dG9uU3RhdGVUb09uKHRoaXMucHVibGlzaGVkQnV0dG9uKTtcclxuICAgICAgICAgICAgdGhpcy5zZXRCdXR0b25TdGF0ZVRvT2ZmKHRoaXMudW5wdWJsaXNoZWRCdXR0b24pO1xyXG4gICAgICAgIH0sIGZhbHNlKTtcclxuXHJcbiAgICAgICAgdGhpcy51bnB1Ymxpc2hlZEJ1dHRvbi5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsICgpID0+XHJcbiAgICAgICAge1xyXG4gICAgICAgICAgICB0aGlzLnNob3dDb250ZW50KHRoaXMudW5wdWJsaXNoZWRDb250ZW50RGl2KTtcclxuICAgICAgICAgICAgdGhpcy5oaWRlQ29udGVudCh0aGlzLnB1Ymxpc2hDb250ZW50RGl2KTtcclxuICAgICAgICAgICAgdGhpcy5zZXRCdXR0b25TdGF0ZVRvT24odGhpcy51bnB1Ymxpc2hlZEJ1dHRvbik7XHJcbiAgICAgICAgICAgIHRoaXMuc2V0QnV0dG9uU3RhdGVUb09mZih0aGlzLnB1Ymxpc2hlZEJ1dHRvbik7XHJcbiAgICAgICAgfSwgZmFsc2UpO1xyXG4gICAgfVxyXG5cclxuICAgIEBBdXRvQmluZFxyXG4gICAgcHJpdmF0ZSBzaG93Q29udGVudChlbGVtOiBIVE1MRGl2RWxlbWVudCk6IHZvaWQge1xyXG4gICAgICAgIGVsZW0uY2xhc3NMaXN0LmNvbnRhaW5zKCdoaWRkZW4nKSA/IGVsZW0uY2xhc3NMaXN0LnJlbW92ZSgnaGlkZGVuJykgOiAnJztcclxuICAgIH1cclxuXHJcbiAgICBAQXV0b0JpbmRcclxuICAgIHByaXZhdGUgaGlkZUNvbnRlbnQoZWxlbTogSFRNTERpdkVsZW1lbnQpOiB2b2lkIHtcclxuICAgICAgICBlbGVtLmNsYXNzTGlzdC5jb250YWlucygnaGlkZGVuJykgPyAnJyA6IGVsZW0uY2xhc3NMaXN0LmFkZCgnaGlkZGVuJyk7XHJcbiAgICB9XHJcblxyXG4gICAgQEF1dG9CaW5kXHJcbiAgICBwcml2YXRlIHNldEJ1dHRvblN0YXRlVG9PZmYoYnV0dG9uOiBIVE1MQnV0dG9uRWxlbWVudCk6dm9pZCB7XHJcbiAgICAgICAgY29uc3Qgb24gPSBbJ2JnLW9yYW5nZS03MDAnLCAnaG92ZXI6Ymctb3JhbmdlLTYwMCcsICd0ZXh0LW9yYW5nZS0zMDAnLCAnaG92ZXI6dGV4dC1vcmFuZ2UtOTAwJ107XHJcbiAgICAgICAgY29uc3Qgb2ZmID0gWydiZy1vcmFuZ2UtNjAwJywgJ2hvdmVyOmJnLW9yYW5nZS03MDAnLCAndGV4dC1vcmFuZ2UtNTAwJywgJ2hvdmVyOnRleHQtb3JhbmdlLTMwMCddO1xyXG5cclxuICAgICAgICBpZiAoYnV0dG9uLmNsYXNzTGlzdC5jb250YWlucygnYmctb3JhbmdlLTcwMCcpKSB7XHJcbiAgICAgICAgICAgIGJ1dHRvbi5jbGFzc0xpc3QucmVtb3ZlKC4uLm9uKTtcclxuICAgICAgICAgICAgYnV0dG9uLmNsYXNzTGlzdC5hZGQoLi4ub2ZmKTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG4gICAgQEF1dG9CaW5kXHJcbiAgICBwcml2YXRlIHNldEJ1dHRvblN0YXRlVG9PbihidXR0b246IEhUTUxCdXR0b25FbGVtZW50KTogdm9pZCB7XHJcbiAgICAgICAgY29uc3Qgb24gPSBbJ2JnLW9yYW5nZS03MDAnLCAnaG92ZXI6Ymctb3JhbmdlLTYwMCcsICd0ZXh0LW9yYW5nZS0zMDAnLCAnaG92ZXI6dGV4dC1vcmFuZ2UtOTAwJ107XHJcbiAgICAgICAgY29uc3Qgb2ZmID0gWydiZy1vcmFuZ2UtNjAwJywgJ2hvdmVyOmJnLW9yYW5nZS03MDAnLCAndGV4dC1vcmFuZ2UtNTAwJywgJ2hvdmVyOnRleHQtb3JhbmdlLTMwMCddO1xyXG5cclxuICAgICAgICBpZiAoYnV0dG9uLmNsYXNzTGlzdC5jb250YWlucygnYmctb3JhbmdlLTYwMCcpKSB7XHJcbiAgICAgICAgICAgIGJ1dHRvbi5jbGFzc0xpc3QucmVtb3ZlKC4uLm9mZik7XHJcbiAgICAgICAgICAgIGJ1dHRvbi5jbGFzc0xpc3QuYWRkKC4uLm9uKTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG59IiwiXHJcbmltcG9ydCB7IEF1dG9CaW5kIH0gZnJvbSAnLi4vZGVjb3JhdG9ycy9BdXRvQmluZCc7XHJcblxyXG5leHBvcnQgY2xhc3MgTW9iaWxlTmF2IHtcclxuICAgIGZvb3Rlck5hdjogSFRNTERpdkVsZW1lbnQ7XHJcbiAgICBpbnN0cnVjdG9ySWNvbjogSFRNTERpdkVsZW1lbnQ7XHJcbiAgICBpbnN0cnVjdG9yTWVudTogSFRNTERpdkVsZW1lbnQ7XHJcbiAgICBhZG1pbkljb246IEhUTUxEaXZFbGVtZW50O1xyXG4gICAgYWRtaW5NZW51OiBIVE1MRGl2RWxlbWVudDtcclxuICAgIHNob3dNZW51OiBib29sZWFuO1xyXG5cclxuICAgIGNvbnN0cnVjdG9yKCkge1xyXG4gICAgICAgIHRoaXMuZm9vdGVyTmF2ID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ2Zvb3Rlci1uYXYnKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5pbnN0cnVjdG9ySWNvbiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdtb2JpbGVfaW5faWNvbicpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLmluc3RydWN0b3JNZW51ID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ21vYmlsZV9pbl9tZW51JykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuYWRtaW5JY29uID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ21vYmlsZV9hZF9pY29uJykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuYWRtaW5NZW51ID0gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoJ21vYmlsZV9hZF9tZW51JykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuc2hvd01lbnUgPSBmYWxzZTtcclxuICAgICAgICB0aGlzLmNvbmZpZ3VyZSgpO1xyXG4gICAgfVxyXG5cclxuICAgIGNvbmZpZ3VyZSgpIHtcclxuICAgICAgICBpZiAodGhpcy5pbnN0cnVjdG9ySWNvbiAhPSBudWxsICYmIHRoaXMuaW5zdHJ1Y3Rvck1lbnUgIT0gbnVsbCkge1xyXG4gICAgICAgICAgICB0aGlzLmluc3RydWN0b3JJY29uLmFkZEV2ZW50TGlzdGVuZXIoJ2NsaWNrJywgKCkgPT4geyB0aGlzLnNob3dNZW51SGFuZGxlcih0aGlzLmluc3RydWN0b3JNZW51KTsgfSwgZmFsc2UpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgaWYgKHRoaXMuYWRtaW5JY29uICE9IG51bGwgJiYgdGhpcy5hZG1pbk1lbnUgIT0gbnVsbCkge1xyXG4gICAgICAgICAgICB0aGlzLmFkbWluSWNvbi5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsICgpID0+IHsgdGhpcy5zaG93TWVudUhhbmRsZXIodGhpcy5hZG1pbk1lbnUpIH0sIGZhbHNlKTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG4gICAgQEF1dG9CaW5kXHJcbiAgICBwcml2YXRlIHNob3dNZW51SGFuZGxlcihtZW51OiBIVE1MRGl2RWxlbWVudCk6IHZvaWQge1xyXG4gICAgICAgIHRoaXMuc2hvd01lbnUgPSAhdGhpcy5zaG93TWVudTtcclxuICAgICAgICB0aGlzLnNob3dNZW51ID09PSB0cnVlID8gbWVudS5jbGFzc0xpc3QucmVtb3ZlKFwiaGlkZGVuXCIpIDogbWVudS5jbGFzc0xpc3QuYWRkKFwiaGlkZGVuXCIpO1xyXG4gICAgfVxyXG59IiwiLy8gYXV0b2JpbmQgZGVjb3JhdG9yXHJcbmV4cG9ydCBmdW5jdGlvbiBBdXRvQmluZChfOiBhbnksIF9fOiBzdHJpbmcsIGRlc2NyaXB0b3I6IFByb3BlcnR5RGVzY3JpcHRvcikge1xyXG4gICAgY29uc3Qgb3JpZ2luYWxNZXRob2QgPSBkZXNjcmlwdG9yLnZhbHVlO1xyXG4gICAgY29uc3QgYWRqRGVzY3JpcHRvcjogUHJvcGVydHlEZXNjcmlwdG9yID0ge1xyXG4gICAgICAgIGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuICAgICAgICBnZXQoKSB7XHJcbiAgICAgICAgICAgIGNvbnN0IGJvdW5kRm4gPSBvcmlnaW5hbE1ldGhvZC5iaW5kKHRoaXMpO1xyXG4gICAgICAgICAgICByZXR1cm4gYm91bmRGbjtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG4gICAgcmV0dXJuIGFkakRlc2NyaXB0b3I7XHJcbn0iXSwic291cmNlUm9vdCI6IiJ9