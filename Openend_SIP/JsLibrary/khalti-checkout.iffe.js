var KhaltiCheckout=function(){"use strict";var t,e,n="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(t){return typeof t}:function(t){return t&&"function"==typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t},i=(function(t,e){Object.defineProperty(e,"__esModule",{value:!0});var i="function"==typeof Symbol&&"symbol"===n(Symbol.iterator)?function(t){return void 0===t?"undefined":n(t)}:function(t){return t&&"function"==typeof Symbol&&t.constructor===Symbol?"symbol":void 0===t?"undefined":n(t)},r=e.SkipValidation=function(t){this.name="SkipValidation",this.message=t},o=e.validateSingle=function(t,e,n,i,o){var a=[];"function"==typeof e&&(e=[e]);for(var u=0;u<e.length;u++)try{var l=e[u](t,i);"string"==typeof l&&a.push(l.replace("{value}",t).replace("{key}",o))}catch(t){if(t instanceof r)break}return!0===n?a:a.length>0?a[0]:void 0};e.validate=function(t,e,n){if(e){var r={},a=!0;if("object"===(void 0===e?"undefined":i(e))&&!e.length){for(var u in e)if(e.hasOwnProperty(u)){var l=o(t[u],e[u],n,t,u);void 0!==l&&(a=!1),r[u]=l}return a?void 0:r}return r=o(t,e,n)}},e.required=function(t,e){function n(t){return void 0===t||""===t||null===t}return function(i){if(t&&n(i))return e||"This field is required.";if(!t&&n(i))throw new r}},e.isNumber=function(t){return function(e){if("number"!=typeof e||isNaN(e))return t||"'{value}' is not a valid number."}},e.isString=function(t){return function(e){if("string"!=typeof e)return t||"'{value}' is not a valid string."}},e.isFunction=function(t){return function(e){if("function"!=typeof e)return t||"Expected a function."}},e.isObject=function(t){return function(e){if(e!==Object(e))return t||"Expected an object."}},e.isArray=function(t){return function(e){if("[object Array]"!==Object.prototype.toString.call(e))return t||"Expected an array."}},e.length=function(t,e){return function(n){if((n+"").length!==t)return e||"It must be "+t+" characters long."}},e.isEmail=function(t){return function(e){if(!/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(e))return t||"Invalid email id."}},e.equalsTo=function(t,e){return function(n,i){if(n!==i[t])return e||"'{key}' and '"+t+"' do not match."}},e.minLength=function(t,e){return function(n){if((n+"").length<t)return e||"It must be at least "+t+" characters long."}},e.maxLength=function(t,e){return function(n){if((n+"").length>t)return e||"It must be at most "+t+" characters long."}},e.isBoolean=function(t){return function(e){if(!0!==e&&!1!==e)return t||"Invalid boolean value."}},e.within=function(t,e){return function(n){n instanceof Array||(n=[n]);for(var i=[],r=0;r<n.length;r++)-1===t.indexOf(n[r])&&i.push(n[r]);if(i.length>0)return e||"["+i+"] do not fall under the allowed list."}},e.excludes=function(t,e){return function(n){n instanceof Array||(n=[n]);for(var i=[],r=0;r<n.length;r++)-1!==t.indexOf(n[r])&&i.push(n[r]);if(i.length>0)return e||"["+i+"] fall under restricted values."}},e.pattern=function(t,e){return function(n){if(!t.test(n))return e||"'{value}' does not match with the pattern."}}}(t={exports:{}},t.exports),t.exports);(e=i)&&e.__esModule&&Object.prototype.hasOwnProperty.call(e,"default")&&e.default;i.SkipValidation,i.validateSingle;var r=i.validate,o=i.required,a=(i.isNumber,i.isString,i.isFunction),u=i.isObject,l=i.isArray,s=(i.length,i.isEmail,i.equalsTo,i.minLength,i.maxLength,i.isBoolean,i.within,i.excludes,i.pattern,function(){function t(t,e){for(var n=0;n<e.length;n++){var i=e[n];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(t,i.key,i)}}return function(e,n,i){return n&&t(e.prototype,n),i&&t(e,i),e}}());var f={EBANKING:"EBANKING",MOBILE_BANKING:"MOBILE_BANKING",CONNECT_IPS:"CONNECT_IPS",SCT:"SCT",KHALTI:"KHALTI"},c=function(t){return t?JSON.parse(JSON.stringify(t)):t},d={onSuccess:[o(!0),a()],onError:[o(!1),a()],onClose:[o(!1),a()]},h={publicKey:o(!0),productUrl:o(!0),productIdentity:o(!0),productName:o(!0),eventHandler:o(!0),amount:o(!0),merchantData:[o(!1),u()],paymentPreference:[o(!1),l()]};return function(){function t(e){!function(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}(this,t),this._widgetId="khalti-widget-"+Date.now(),this._config=e,this._widget=this.attachWidget(),this.listenToWidget(),this.paymentType=f}return s(t,[{key:"listenToWidget",value:function(){var t=this;window.addEventListener("message",function(e){if(e.data.realm)if("widgetInit"===e.data.realm)t.widgetInit(e.data.payload);else{if(!e.data.payload||e.data.payload.widget_id!==t._widgetId)return;var n="handle_msg_"+e.data.realm;t[n](e.data.payload)}},!1)}},{key:"msgWidget",value:function(t,e){(e=c(e)).widgetId=this._widgetId,e.source="checkout_v2",this._widget.contentWindow.postMessage({realm:t,payload:e},"*")}},{key:"handle_msg_widgetInit",value:function(){this.widgetInit()}},{key:"widgetInit",value:function(){var t=c(this._config);delete t.eventHandler,this.msgWidget("paymentInfo",t)}},{key:"validateConfig",value:function(){var t=r(this._config,h);if(t)throw new Error(JSON.stringify(t));var e=r(this._config.eventHandler,d);if(e)throw new Error(JSON.stringify({eventHandler:e}))}},{key:"handle_msg_walletPaymentVerification",value:function(t){this._config.eventHandler.onSuccess(t),this.hide()}},{key:"handle_msg_widgetError",value:function(t){var e=this._config.eventHandler.onError;e&&e(t)}},{key:"disableParentScrollbar",value:function(){this.parentOverflowValue=window.document.body.style.overflowY,window.document.body.style.overflowY="hidden"}},{key:"enableParentScrollbar",value:function(){window.document.body.style.overflowY=this.parentOverflowValue,this.parentOverflowValue=null}},{key:"show",value:function(t){Object.assign(this._config,t),this.validateConfig(),this.disableParentScrollbar(),this._widget.style.display="block",this.widgetInit()}},{key:"handle_msg_hide",value:function(){this.hide();var t=this._config.eventHandler.onClose;t&&t()}},{key:"hide",value:function(){this.enableParentScrollbar(),this._widget.style.display="none"}},{key:"attachWidget",value:function(){var t=window.document.createElement("iframe");return t.setAttribute("id",this._widgetId),t.style.position="fixed",t.style.display="none",t.style.top="0",t.style.left="0",t.width="100%",t.height=window.innerHeight+"px",t.setAttribute("src","https://khalti.s3.ap-south-1.amazonaws.com/KPG/dist/2020.10.09.0.0.4/payment_gateway_widget.html"),t.style.zIndex=99999,t.setAttribute("frameborder",0),t.setAttribute("allowtransparency",!0),window.document.body.appendChild(t),t}}]),t}()}();