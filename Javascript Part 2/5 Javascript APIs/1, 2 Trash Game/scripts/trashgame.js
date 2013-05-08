(function () {
    var numberOfTrash = 15;
    
    var trash = document.createElement('div');
    var trashImage = document.createElement('img');
    trashImage.setAttribute('src','images/trash.png');
    trash.appendChild(trashImage.cloneNode(true));
    trash.setAttribute('draggable', 'true');
    trash.style.position = 'relative';
    trash.style.right = Math.random() * document.body.scrollWidth ;
    trash.style.top = Math.random() * document.body.scrollHeight;
    trash.style.width = '20px';

    for (var i = 0; i < numberOfTrash; i++) {
        var newChild = trash.cloneNode(true);
        newChild.style.left = Math.random() * window.innerWidth;
        newChild.style.top = Math.random() * window.innerHeight;
        document.querySelector('body').appendChild(newChild);
    }
})();