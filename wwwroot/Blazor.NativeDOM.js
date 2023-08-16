export function getAttribute(object, attribute) {
    return object[attribute];
}

export function setAttribute(object, attribute, value) {
    object[attribute] = value;
}

export function getJSReference(element) {
    return element.valueOf();
}

export function addEventListener(target, type, eventListener = null, options = null) {
    target.addEventListener(type, eventListener, options)
}

export function removeEventListener(target, type, eventListener = null, options) {
    target.removeEventListener(type, eventListener, options)
}

export function constructEventListener() {
    return {};
}

export function registerEventHandlerAsync(objRef, jSInstance) {
    jSInstance.handleEvent = (e) => objRef.invokeMethodAsync("HandleEventAsync", DotNet.createJSObjectReference(e))
}

export function registerInProcessEventHandlerAsync(objRef, jSInstance) {
    jSInstance.handleEvent = (e) => objRef.invokeMethodAsync("HandleEventInProcessAsync", DotNet.createJSObjectReference(e))
}

export function constructEvent(type, eventInitDict = null) {
    return new Event(type, eventInitDict);
}

export function constructCustomEvent(type, eventInitDict = null) {
    return new CustomEvent(type, eventInitDict);
}

export function constructEventTarget() {
    return new EventTarget();
}

export function constructAbortController() {
    return new AbortController();
}

export function constructNode() {
    return new Node();
}

export function constructWindow() {
    return window;
}

export function constructLocation() {
    return new Location();
}

export function constructScreen() {
    return new Screen();
}

export function constructScreenOrientation() {
    return new ScreenOrientation();
}

export function constructDOMStringList() {
    return new DOMStringList();
}