function onsubmitclick()
{
    var dvChatWindow = document.getElementById("dvChatWindow");
    creatediv("dvBunny" + (new Date()).toUTCString().replace(/[^\w]/g, ''), dvChatWindow);

}

function creatediv(divname,parent){
    if(parent==null){
        parent=document.getElementsByTagName('body')[0];
    }
    var dvChd = document.createElement('div');
    dvChd.setAttribute('id', divname);
    var textstring = document.getElementById('text1');
    var schat = document.createElement('span');
    schat.innerHTML = textstring.value;
    dvChd.appendChild(schat);
    parent.appendChild(dvChd);
}
