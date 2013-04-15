function onButtonClick (clickEvent, args) {
	var userWindow = window;
	var userBrowser = userWindow.navigator.appCodeName;
	var isMozilla = userBrowser == "Mozilla";
	
	if (isMozilla) {
		alert("Yes");
	} else {
		alert("No");
	}
}
