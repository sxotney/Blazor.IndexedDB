//https://github.com/mono/mono/blob/master/sdks/wasm/src/binding_support.js 4/24/2020
//https://github.com/dotnet/aspnetcore/blob/master/src/Components/Web.JS/src/Platform/Mono/MonoPlatform.ts

window.FastInterop = {
    SetStringData: function (v, t) {
        this[BINDING.conv_string(v)] = BINDING.conv_string(t);
        return true;
    },
    SetBinaryData: function (v, d) {
        window[BINDING.conv_string(v)] = Blazor.platform.toUint8Array(d);
        return true;
    },
    GetStringData: function (v) {
        var variableName = BINDING.conv_string(v);
        var result = this[variableName];
        delete this[variableName];
        return BINDING.js_to_mono_obj(result);
    },
    GetBinaryDataLength: function (v) {
        var variableName = BINDING.conv_string(v);
        return window[variableName].byteLength;
    },
    GetBinaryData: function (v, d) {
        var variableName = BINDING.conv_string(v);
        var result = window[variableName];
        var destinationUint8Array = Blazor.platform.toUint8Array(d);
        destinationUint8Array.set(result);
        delete window[variableName];
        return true;
    },
  
};
