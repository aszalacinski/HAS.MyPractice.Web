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
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vLy4vU2NyaXB0cy9jc3Mvc3R5bGVzLmNzcz8wM2M2Iiwid2VicGFjazovLy8uL1NjcmlwdHMvdHMvQXBwLnRzIiwid2VicGFjazovLy8uL1NjcmlwdHMvdHMvY29tcG9uZW50cy9Db250ZW50TGlzdC50cyIsIndlYnBhY2s6Ly8vLi9TY3JpcHRzL3RzL2NvbXBvbmVudHMvTW9iaWxlTmF2LnRzIiwid2VicGFjazovLy8uL1NjcmlwdHMvdHMvZGVjb3JhdG9ycy9BdXRvQmluZC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiO1FBQUE7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7OztRQUdBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQSwwQ0FBMEMsZ0NBQWdDO1FBQzFFO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0Esd0RBQXdELGtCQUFrQjtRQUMxRTtRQUNBLGlEQUFpRCxjQUFjO1FBQy9EOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQSx5Q0FBeUMsaUNBQWlDO1FBQzFFLGdIQUFnSCxtQkFBbUIsRUFBRTtRQUNySTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBLDJCQUEyQiwwQkFBMEIsRUFBRTtRQUN2RCxpQ0FBaUMsZUFBZTtRQUNoRDtRQUNBO1FBQ0E7O1FBRUE7UUFDQSxzREFBc0QsK0RBQStEOztRQUVySDtRQUNBOzs7UUFHQTtRQUNBOzs7Ozs7Ozs7Ozs7QUNsRkEsdUM7Ozs7Ozs7Ozs7OztBQ0FBO0FBQUE7QUFBQTtBQUFtRDtBQUNJO0FBRXZELE9BQU8sQ0FBQyxHQUFHLENBQUMsb0JBQW9CLENBQUMsQ0FBQztBQUVsQyxJQUFJLCtEQUFT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QUFnQixDQUFDLE9BQU8sRUFBRSxHQUFHLEVBQUUsR0FBRSxJQUFJLENBQUMsZUFBZSxDQUFDLElBQUksQ0FBQyxjQUFjLENBQUMsQ0FBQyxFQUFDLEVBQUUsS0FBSyxDQUFDLENBQUM7UUFDekcsSUFBSSxDQUFDLFNBQVMsQ0FBQyxnQkFBZ0IsQ0FBQyxPQUFPLEVBQUUsR0FBRyxFQUFFLEdBQUcsSUFBSSxDQUFDLGVBQWUsQ0FBQyxJQUFJLENBQUMsU0FBUyxDQUFDLEVBQUMsQ0FBQyxFQUFFLEtBQUssQ0FBQyxDQUFDO0lBQ3BHLENBQUM7SUFHTyxlQUFlLENBQUMsSUFBb0I7UUFDeEMsSUFBSSxDQUFDLFFBQVEsR0FBRyxDQUFDLElBQUksQ0FBQyxRQUFRLENBQUM7UUFDL0IsSUFBSSxDQUFDLFFBQVEsS0FBSyxJQUFJLENBQUMsQ0FBQyxDQUFDLElBQUksQ0FBQyxTQUFTLENBQUMsTUFBTSxDQUFDLFFBQVEsQ0FBQyxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsU0FBUyxDQUFDLEdBQUcsQ0FBQyxRQUFRLENBQUMsQ0FBQztJQUM1RixDQUFDO0NBQ0o7QUFKRztJQURDLDZEQUFROztxQ0FDcUIsY0FBYzs7Z0RBRzNDOzs7Ozs7Ozs7Ozs7O0FDN0JMO0FBQUE7QUFBTyxTQUFTLFFBQVEsQ0FBQyxDQUFNLEVBQUUsRUFBVSxFQUFFLFVBQThCO0lBQ3ZFLE1BQU0sY0FBYyxHQUFHLFVBQVUsQ0FBQyxLQUFLLENBQUM7SUFDeEMsTUFBTSxhQUFhLEdBQXVCO1FBQ3RDLFlBQVksRUFBRSxJQUFJO1FBQ2xCLEdBQUc7WUFDQyxNQUFNLE9BQU8sR0FBRyxjQUFjLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxDQUFDO1lBQzFDLE9BQU8sT0FBTyxDQUFDO1FBQ25CLENBQUM7S0FDSixDQUFDO0lBQ0YsT0FBTyxhQUFhLENBQUM7QUFDekIsQ0FBQyIsImZpbGUiOiJzaXRlLmpzIiwic291cmNlc0NvbnRlbnQiOlsiIFx0Ly8gVGhlIG1vZHVsZSBjYWNoZVxuIFx0dmFyIGluc3RhbGxlZE1vZHVsZXMgPSB7fTtcblxuIFx0Ly8gVGhlIHJlcXVpcmUgZnVuY3Rpb25cbiBcdGZ1bmN0aW9uIF9fd2VicGFja19yZXF1aXJlX18obW9kdWxlSWQpIHtcblxuIFx0XHQvLyBDaGVjayBpZiBtb2R1bGUgaXMgaW4gY2FjaGVcbiBcdFx0aWYoaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0pIHtcbiBcdFx0XHRyZXR1cm4gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0uZXhwb3J0cztcbiBcdFx0fVxuIFx0XHQvLyBDcmVhdGUgYSBuZXcgbW9kdWxlIChhbmQgcHV0IGl0IGludG8gdGhlIGNhY2hlKVxuIFx0XHR2YXIgbW9kdWxlID0gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0gPSB7XG4gXHRcdFx0aTogbW9kdWxlSWQsXG4gXHRcdFx0bDogZmFsc2UsXG4gXHRcdFx0ZXhwb3J0czoge31cbiBcdFx0fTtcblxuIFx0XHQvLyBFeGVjdXRlIHRoZSBtb2R1bGUgZnVuY3Rpb25cbiBcdFx0bW9kdWxlc1ttb2R1bGVJZF0uY2FsbChtb2R1bGUuZXhwb3J0cywgbW9kdWxlLCBtb2R1bGUuZXhwb3J0cywgX193ZWJwYWNrX3JlcXVpcmVfXyk7XG5cbiBcdFx0Ly8gRmxhZyB0aGUgbW9kdWxlIGFzIGxvYWRlZFxuIFx0XHRtb2R1bGUubCA9IHRydWU7XG5cbiBcdFx0Ly8gUmV0dXJuIHRoZSBleHBvcnRzIG9mIHRoZSBtb2R1bGVcbiBcdFx0cmV0dXJuIG1vZHVsZS5leHBvcnRzO1xuIFx0fVxuXG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlcyBvYmplY3QgKF9fd2VicGFja19tb2R1bGVzX18pXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm0gPSBtb2R1bGVzO1xuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZSBjYWNoZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5jID0gaW5zdGFsbGVkTW9kdWxlcztcblxuIFx0Ly8gZGVmaW5lIGdldHRlciBmdW5jdGlvbiBmb3IgaGFybW9ueSBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQgPSBmdW5jdGlvbihleHBvcnRzLCBuYW1lLCBnZXR0ZXIpIHtcbiBcdFx0aWYoIV9fd2VicGFja19yZXF1aXJlX18ubyhleHBvcnRzLCBuYW1lKSkge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBuYW1lLCB7IGVudW1lcmFibGU6IHRydWUsIGdldDogZ2V0dGVyIH0pO1xuIFx0XHR9XG4gXHR9O1xuXG4gXHQvLyBkZWZpbmUgX19lc01vZHVsZSBvbiBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnIgPSBmdW5jdGlvbihleHBvcnRzKSB7XG4gXHRcdGlmKHR5cGVvZiBTeW1ib2wgIT09ICd1bmRlZmluZWQnICYmIFN5bWJvbC50b1N0cmluZ1RhZykge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBTeW1ib2wudG9TdHJpbmdUYWcsIHsgdmFsdWU6ICdNb2R1bGUnIH0pO1xuIFx0XHR9XG4gXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCAnX19lc01vZHVsZScsIHsgdmFsdWU6IHRydWUgfSk7XG4gXHR9O1xuXG4gXHQvLyBjcmVhdGUgYSBmYWtlIG5hbWVzcGFjZSBvYmplY3RcbiBcdC8vIG1vZGUgJiAxOiB2YWx1ZSBpcyBhIG1vZHVsZSBpZCwgcmVxdWlyZSBpdFxuIFx0Ly8gbW9kZSAmIDI6IG1lcmdlIGFsbCBwcm9wZXJ0aWVzIG9mIHZhbHVlIGludG8gdGhlIG5zXG4gXHQvLyBtb2RlICYgNDogcmV0dXJuIHZhbHVlIHdoZW4gYWxyZWFkeSBucyBvYmplY3RcbiBcdC8vIG1vZGUgJiA4fDE6IGJlaGF2ZSBsaWtlIHJlcXVpcmVcbiBcdF9fd2VicGFja19yZXF1aXJlX18udCA9IGZ1bmN0aW9uKHZhbHVlLCBtb2RlKSB7XG4gXHRcdGlmKG1vZGUgJiAxKSB2YWx1ZSA9IF9fd2VicGFja19yZXF1aXJlX18odmFsdWUpO1xuIFx0XHRpZihtb2RlICYgOCkgcmV0dXJuIHZhbHVlO1xuIFx0XHRpZigobW9kZSAmIDQpICYmIHR5cGVvZiB2YWx1ZSA9PT0gJ29iamVjdCcgJiYgdmFsdWUgJiYgdmFsdWUuX19lc01vZHVsZSkgcmV0dXJuIHZhbHVlO1xuIFx0XHR2YXIgbnMgPSBPYmplY3QuY3JlYXRlKG51bGwpO1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLnIobnMpO1xuIFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkobnMsICdkZWZhdWx0JywgeyBlbnVtZXJhYmxlOiB0cnVlLCB2YWx1ZTogdmFsdWUgfSk7XG4gXHRcdGlmKG1vZGUgJiAyICYmIHR5cGVvZiB2YWx1ZSAhPSAnc3RyaW5nJykgZm9yKHZhciBrZXkgaW4gdmFsdWUpIF9fd2VicGFja19yZXF1aXJlX18uZChucywga2V5LCBmdW5jdGlvbihrZXkpIHsgcmV0dXJuIHZhbHVlW2tleV07IH0uYmluZChudWxsLCBrZXkpKTtcbiBcdFx0cmV0dXJuIG5zO1xuIFx0fTtcblxuIFx0Ly8gZ2V0RGVmYXVsdEV4cG9ydCBmdW5jdGlvbiBmb3IgY29tcGF0aWJpbGl0eSB3aXRoIG5vbi1oYXJtb255IG1vZHVsZXNcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubiA9IGZ1bmN0aW9uKG1vZHVsZSkge1xuIFx0XHR2YXIgZ2V0dGVyID0gbW9kdWxlICYmIG1vZHVsZS5fX2VzTW9kdWxlID9cbiBcdFx0XHRmdW5jdGlvbiBnZXREZWZhdWx0KCkgeyByZXR1cm4gbW9kdWxlWydkZWZhdWx0J107IH0gOlxuIFx0XHRcdGZ1bmN0aW9uIGdldE1vZHVsZUV4cG9ydHMoKSB7IHJldHVybiBtb2R1bGU7IH07XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18uZChnZXR0ZXIsICdhJywgZ2V0dGVyKTtcbiBcdFx0cmV0dXJuIGdldHRlcjtcbiBcdH07XG5cbiBcdC8vIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbFxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5vID0gZnVuY3Rpb24ob2JqZWN0LCBwcm9wZXJ0eSkgeyByZXR1cm4gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsKG9iamVjdCwgcHJvcGVydHkpOyB9O1xuXG4gXHQvLyBfX3dlYnBhY2tfcHVibGljX3BhdGhfX1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5wID0gXCJcIjtcblxuXG4gXHQvLyBMb2FkIGVudHJ5IG1vZHVsZSBhbmQgcmV0dXJuIGV4cG9ydHNcbiBcdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKF9fd2VicGFja19yZXF1aXJlX18ucyA9IDApO1xuIiwiLy8gZXh0cmFjdGVkIGJ5IG1pbmktY3NzLWV4dHJhY3QtcGx1Z2luIiwiaW1wb3J0IHsgTW9iaWxlTmF2IH0gZnJvbSBcIi4vY29tcG9uZW50cy9Nb2JpbGVOYXZcIjtcclxuaW1wb3J0IHsgQ29udGVudExpc3QgfSBmcm9tIFwiLi9jb21wb25lbnRzL0NvbnRlbnRMaXN0XCI7XHJcblxyXG5jb25zb2xlLmxvZyhcIkhBUy5NeVByYWN0aWNlLldlYlwiKTtcclxuXHJcbm5ldyBNb2JpbGVOYXYoKTtcclxubmV3IENvbnRlbnRMaXN0KCk7IiwiXHJcbmltcG9ydCB7IEF1dG9CaW5kIH0gZnJvbSAnLi4vZGVjb3JhdG9ycy9BdXRvQmluZCc7XHJcblxyXG5leHBvcnQgY2xhc3MgQ29udGVudExpc3Qge1xyXG4gICAgcHVibGlzaGVkQnV0dG9uOiBIVE1MQnV0dG9uRWxlbWVudDtcclxuICAgIHB1Ymxpc2hDb250ZW50RGl2OiBIVE1MRGl2RWxlbWVudDtcclxuICAgIHVucHVibGlzaGVkQnV0dG9uOiBIVE1MQnV0dG9uRWxlbWVudDtcclxuICAgIHVucHVibGlzaGVkQ29udGVudERpdjogSFRNTERpdkVsZW1lbnQ7XHJcblxyXG4gICAgY29uc3RydWN0b3IoKSB7XHJcbiAgICAgICAgdGhpcy5wdWJsaXNoZWRCdXR0b24gPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgncHVibGlzaGVkQnV0dG9uJykhIGFzIEhUTUxCdXR0b25FbGVtZW50O1xyXG4gICAgICAgIHRoaXMucHVibGlzaENvbnRlbnREaXYgPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgncHVibGlzaGVkLWNvbnRlbnQnKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy51bnB1Ymxpc2hlZEJ1dHRvbiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCd1bnB1Ymxpc2hlZEJ1dHRvbicpISBhcyBIVE1MQnV0dG9uRWxlbWVudDtcclxuICAgICAgICB0aGlzLnVucHVibGlzaGVkQ29udGVudERpdiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCd1bnB1Ymxpc2hlZC1jb250ZW50JykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuY29uZmlndXJlKCk7XHJcbiAgICB9XHJcblxyXG4gICAgY29uZmlndXJlKCkge1xyXG4gICAgICAgIHRoaXMucHVibGlzaGVkQnV0dG9uLmFkZEV2ZW50TGlzdGVuZXIoJ2NsaWNrJywgKCkgPT5cclxuICAgICAgICB7XHJcbiAgICAgICAgICAgIHRoaXMuc2hvd0NvbnRlbnQodGhpcy5wdWJsaXNoQ29udGVudERpdik7XHJcbiAgICAgICAgICAgIHRoaXMuaGlkZUNvbnRlbnQodGhpcy51bnB1Ymxpc2hlZENvbnRlbnREaXYpO1xyXG4gICAgICAgICAgICB0aGlzLnNldEJ1dHRvblN0YXRlVG9Pbih0aGlzLnB1Ymxpc2hlZEJ1dHRvbik7XHJcbiAgICAgICAgICAgIHRoaXMuc2V0QnV0dG9uU3RhdGVUb09mZih0aGlzLnVucHVibGlzaGVkQnV0dG9uKTtcclxuICAgICAgICB9LCBmYWxzZSk7XHJcblxyXG4gICAgICAgIHRoaXMudW5wdWJsaXNoZWRCdXR0b24uYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoKSA9PlxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgdGhpcy5zaG93Q29udGVudCh0aGlzLnVucHVibGlzaGVkQ29udGVudERpdik7XHJcbiAgICAgICAgICAgIHRoaXMuaGlkZUNvbnRlbnQodGhpcy5wdWJsaXNoQ29udGVudERpdik7XHJcbiAgICAgICAgICAgIHRoaXMuc2V0QnV0dG9uU3RhdGVUb09uKHRoaXMudW5wdWJsaXNoZWRCdXR0b24pO1xyXG4gICAgICAgICAgICB0aGlzLnNldEJ1dHRvblN0YXRlVG9PZmYodGhpcy5wdWJsaXNoZWRCdXR0b24pO1xyXG4gICAgICAgIH0sIGZhbHNlKTtcclxuICAgIH1cclxuXHJcbiAgICBAQXV0b0JpbmRcclxuICAgIHByaXZhdGUgc2hvd0NvbnRlbnQoZWxlbTogSFRNTERpdkVsZW1lbnQpOiB2b2lkIHtcclxuICAgICAgICBlbGVtLmNsYXNzTGlzdC5jb250YWlucygnaGlkZGVuJykgPyBlbGVtLmNsYXNzTGlzdC5yZW1vdmUoJ2hpZGRlbicpIDogJyc7XHJcbiAgICB9XHJcblxyXG4gICAgQEF1dG9CaW5kXHJcbiAgICBwcml2YXRlIGhpZGVDb250ZW50KGVsZW06IEhUTUxEaXZFbGVtZW50KTogdm9pZCB7XHJcbiAgICAgICAgZWxlbS5jbGFzc0xpc3QuY29udGFpbnMoJ2hpZGRlbicpID8gJycgOiBlbGVtLmNsYXNzTGlzdC5hZGQoJ2hpZGRlbicpO1xyXG4gICAgfVxyXG5cclxuICAgIEBBdXRvQmluZFxyXG4gICAgcHJpdmF0ZSBzZXRCdXR0b25TdGF0ZVRvT2ZmKGJ1dHRvbjogSFRNTEJ1dHRvbkVsZW1lbnQpOnZvaWQge1xyXG4gICAgICAgIGNvbnN0IG9uID0gWydiZy1vcmFuZ2UtNzAwJywgJ2hvdmVyOmJnLW9yYW5nZS02MDAnLCAndGV4dC1vcmFuZ2UtMzAwJywgJ2hvdmVyOnRleHQtb3JhbmdlLTkwMCddO1xyXG4gICAgICAgIGNvbnN0IG9mZiA9IFsnYmctb3JhbmdlLTYwMCcsICdob3ZlcjpiZy1vcmFuZ2UtNzAwJywgJ3RleHQtb3JhbmdlLTUwMCcsICdob3Zlcjp0ZXh0LW9yYW5nZS0zMDAnXTtcclxuXHJcbiAgICAgICAgaWYgKGJ1dHRvbi5jbGFzc0xpc3QuY29udGFpbnMoJ2JnLW9yYW5nZS03MDAnKSkge1xyXG4gICAgICAgICAgICBidXR0b24uY2xhc3NMaXN0LnJlbW92ZSguLi5vbik7XHJcbiAgICAgICAgICAgIGJ1dHRvbi5jbGFzc0xpc3QuYWRkKC4uLm9mZik7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxuICAgIEBBdXRvQmluZFxyXG4gICAgcHJpdmF0ZSBzZXRCdXR0b25TdGF0ZVRvT24oYnV0dG9uOiBIVE1MQnV0dG9uRWxlbWVudCk6IHZvaWQge1xyXG4gICAgICAgIGNvbnN0IG9uID0gWydiZy1vcmFuZ2UtNzAwJywgJ2hvdmVyOmJnLW9yYW5nZS02MDAnLCAndGV4dC1vcmFuZ2UtMzAwJywgJ2hvdmVyOnRleHQtb3JhbmdlLTkwMCddO1xyXG4gICAgICAgIGNvbnN0IG9mZiA9IFsnYmctb3JhbmdlLTYwMCcsICdob3ZlcjpiZy1vcmFuZ2UtNzAwJywgJ3RleHQtb3JhbmdlLTUwMCcsICdob3Zlcjp0ZXh0LW9yYW5nZS0zMDAnXTtcclxuXHJcbiAgICAgICAgaWYgKGJ1dHRvbi5jbGFzc0xpc3QuY29udGFpbnMoJ2JnLW9yYW5nZS02MDAnKSkge1xyXG4gICAgICAgICAgICBidXR0b24uY2xhc3NMaXN0LnJlbW92ZSguLi5vZmYpO1xyXG4gICAgICAgICAgICBidXR0b24uY2xhc3NMaXN0LmFkZCguLi5vbik7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxufSIsIlxyXG5pbXBvcnQgeyBBdXRvQmluZCB9IGZyb20gJy4uL2RlY29yYXRvcnMvQXV0b0JpbmQnO1xyXG5cclxuZXhwb3J0IGNsYXNzIE1vYmlsZU5hdiB7XHJcbiAgICBmb290ZXJOYXY6IEhUTUxEaXZFbGVtZW50O1xyXG4gICAgaW5zdHJ1Y3Rvckljb246IEhUTUxEaXZFbGVtZW50O1xyXG4gICAgaW5zdHJ1Y3Rvck1lbnU6IEhUTUxEaXZFbGVtZW50O1xyXG4gICAgYWRtaW5JY29uOiBIVE1MRGl2RWxlbWVudDtcclxuICAgIGFkbWluTWVudTogSFRNTERpdkVsZW1lbnQ7XHJcbiAgICBzaG93TWVudTogYm9vbGVhbjtcclxuXHJcbiAgICBjb25zdHJ1Y3RvcigpIHtcclxuICAgICAgICB0aGlzLmZvb3Rlck5hdiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdmb290ZXItbmF2JykhIGFzIEhUTUxEaXZFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuaW5zdHJ1Y3Rvckljb24gPSBkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnbW9iaWxlX2luX2ljb24nKSEgYXMgSFRNTERpdkVsZW1lbnQ7XHJcbiAgICAgICAgdGhpcy5pbnN0cnVjdG9yTWVudSA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdtb2JpbGVfaW5fbWVudScpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLmFkbWluSWNvbiA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdtb2JpbGVfYWRfaWNvbicpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLmFkbWluTWVudSA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdtb2JpbGVfYWRfbWVudScpISBhcyBIVE1MRGl2RWxlbWVudDtcclxuICAgICAgICB0aGlzLnNob3dNZW51ID0gZmFsc2U7XHJcbiAgICAgICAgdGhpcy5jb25maWd1cmUoKTtcclxuICAgIH1cclxuXHJcbiAgICBjb25maWd1cmUoKSB7XHJcbiAgICAgICAgdGhpcy5pbnN0cnVjdG9ySWNvbi5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsICgpID0+IHt0aGlzLnNob3dNZW51SGFuZGxlcih0aGlzLmluc3RydWN0b3JNZW51KTt9LCBmYWxzZSk7XHJcbiAgICAgICAgdGhpcy5hZG1pbkljb24uYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoKSA9PiB7IHRoaXMuc2hvd01lbnVIYW5kbGVyKHRoaXMuYWRtaW5NZW51KSB9LCBmYWxzZSk7XHJcbiAgICB9XHJcblxyXG4gICAgQEF1dG9CaW5kXHJcbiAgICBwcml2YXRlIHNob3dNZW51SGFuZGxlcihtZW51OiBIVE1MRGl2RWxlbWVudCk6IHZvaWQge1xyXG4gICAgICAgIHRoaXMuc2hvd01lbnUgPSAhdGhpcy5zaG93TWVudTtcclxuICAgICAgICB0aGlzLnNob3dNZW51ID09PSB0cnVlID8gbWVudS5jbGFzc0xpc3QucmVtb3ZlKFwiaGlkZGVuXCIpIDogbWVudS5jbGFzc0xpc3QuYWRkKFwiaGlkZGVuXCIpO1xyXG4gICAgfVxyXG59IiwiLy8gYXV0b2JpbmQgZGVjb3JhdG9yXHJcbmV4cG9ydCBmdW5jdGlvbiBBdXRvQmluZChfOiBhbnksIF9fOiBzdHJpbmcsIGRlc2NyaXB0b3I6IFByb3BlcnR5RGVzY3JpcHRvcikge1xyXG4gICAgY29uc3Qgb3JpZ2luYWxNZXRob2QgPSBkZXNjcmlwdG9yLnZhbHVlO1xyXG4gICAgY29uc3QgYWRqRGVzY3JpcHRvcjogUHJvcGVydHlEZXNjcmlwdG9yID0ge1xyXG4gICAgICAgIGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuICAgICAgICBnZXQoKSB7XHJcbiAgICAgICAgICAgIGNvbnN0IGJvdW5kRm4gPSBvcmlnaW5hbE1ldGhvZC5iaW5kKHRoaXMpO1xyXG4gICAgICAgICAgICByZXR1cm4gYm91bmRGbjtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG4gICAgcmV0dXJuIGFkakRlc2NyaXB0b3I7XHJcbn0iXSwic291cmNlUm9vdCI6IiJ9