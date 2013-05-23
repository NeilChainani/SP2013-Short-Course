Type.registerNamespace('ContextualTabWebPart');

var _webPartPageComponentId;
ContextualTabWebPart.CustomPageComponent = function ContextualTabWebPart_CustomPageComponent(webPartPcId) {
    this._webPartPageComponentId = webPartPcId;
    ContextualTabWebPart.CustomPageComponent.initializeBase(this);
}
ContextualTabWebPart.CustomPageComponent.prototype = {
    init: function ContextualTabWebPart_CustomPageComponent$init() { },
    getFocusedCommands: function ContextualTabWebPart_CustomPageComponent$getFocusedCommands() {
        return ['CustomContextualTab.EnableCustomTab', 'CustomContextualTab.EnableCustomGroup', 'CustomContextualTab.HelloWorldCommand', 'CustomContextualTab.GoodbyeWorldCommand'];
    },
    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        return [];
    },
    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },
    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {
        if ((commandId === 'CustomContextualTab.EnableCustomTab') || (commandId === 'CustomContextualTab.EnableCustomGroup') || (commandId === 'CustomContextualTab.HelloWorldCommand') || (commandId === 'CustomContextualTab.GoodbyeWorldCommand')) {
            return true;
        }
    },
    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {
        if (commandId === 'CustomContextualTab.HelloWorldCommand') {
            alert('Hello, world!');
        }
        if (commandId === 'CustomContextualTab.GoodbyeWorldCommand') {
            alert('Good-bye, world!');
        }
    },
    getId: function ContextualTabWebPart_CustomPageComponent$getId() {
        return this._webPartPageComponentId;
    }
}
ContextualTabWebPart.CustomPageComponent.registerClass('ContextualTabWebPart.CustomPageComponent', CUI.Page.PageComponent);
SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("CustomContextualTabPageComponent.js");