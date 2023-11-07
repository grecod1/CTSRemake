function determineBrowser(){  
    var browser;
    if(navigator.userAgent.indexOf('MSIE') != -1 || !! document.documentMode == true){
        browser = 'IE'
    } 
    else if(navigator.userAgent.indexOf('Firefox') != -1) {
        browser = 'Firefox';
    }
    else if(navigator.userAgent.indexOf('Chrome') != -1){
        browser = 'Chrome';
    }
    else if(navigator.userAgent.indexOf('Opera') != -1){
        browser = 'Opera';
    }
    else if(navigator.userAgent.indexOf('Edge') != -1){
        browser = 'Edge'
    }
    else{
        browser = 'Unkown';
    }    
    return browser;
}