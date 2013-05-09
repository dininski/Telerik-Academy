var trashGame = (function () {
    var NUMBER_OF_TRASH = 10;

    var TRASH = document.createElement('div');
    var TRASH_IMAGE = document.createElement('img');
    var TRASHCAN = document.getElementById('trashcan');
    var GAME_CONTAINER = document.getElementById('playingField');
    var TOP_SCORES_CONTAINER = document.getElementById('hi-scores');
    var currentNumberOfTrash;
    var timeTaken;
    var timeController;

    createTrashElement();
    setTrashcanAttributes();

    function startGame() {
        timeTaken = 0;
        clearInterval(timeController);
        currentNumberOfTrash = NUMBER_OF_TRASH;
        clearAllTrash();
        generateTrash();
        timeController = setInterval(function () {
            timeTaken++;
        }, 10);
    }

    function endGame() {
        clearInterval(timeController);
        var playerName = prompt('Your score is: ' + timeTaken + ' (the lower the better). Please enter your name:');
        localStorage.setItem(timeTaken, playerName);
        updateScores();
    }

    function updateScores() {
        var sortedScores = Object.keys(localStorage).sort(function (a, b) {
            return a - b;
        });

        var usersDisplayed = 1;

        for (var score in sortedScores) {
            if (usersDisplayed > 5) {
                break;
            }

            var playerScore = sortedScores[score];
            var playerName = localStorage.getItem(sortedScores[score]);
            var scoreToDisplay = document.createElement('div');

            scoreToDisplay.innerText = 'Name: ' + playerName + ' Score: ' + playerScore;
            TOP_SCORES_CONTAINER.appendChild(scoreToDisplay);
            usersDisplayed++;
        }


    }

    function setTrashcanAttributes() {
        TRASHCAN.setAttribute('ondragover', 'trashGame.allowDrop(event)');
        TRASHCAN.setAttribute('ondrop', 'trashGame.drop(event)');

        TRASHCAN.addEventListener('dragenter', function (event) {
            event.target.setAttribute('src', 'images/trashcan_open.png');
        });

        TRASHCAN.addEventListener('dragleave', function (event) {
            event.target.setAttribute('src', 'images/trashcan_closed.png');
        });
    }

    function closeCan() {
        TRASHCAN.setAttribute('src', 'images/trashcan_closed.png');
    }

    function openCan() {
        TRASHCAN.setAttribute('src', 'images/trashcan_open.png');
    }

    function createTrashElement() {
        TRASH_IMAGE.setAttribute('src', 'images/trash.png');
        TRASH.appendChild(TRASH_IMAGE.cloneNode(true));
        TRASH.setAttribute('draggable', 'true');
        TRASH.style.position = 'absolute';
        TRASH.style.left = Math.round(Math.random() * 90) + '%';
        TRASH.style.top = Math.round(Math.random() * 90) + '%';
        TRASH.style.width = '20px';
        TRASH.setAttribute('ondragstart', 'trashGame.drag(event)');
    }

    function generateTrash() {
        for (var i = 0; i < NUMBER_OF_TRASH; i++) {
            var newTrashElement = TRASH.cloneNode(true);
            newTrashElement.style.left = Math.round(Math.random() * 90) + '%';
            newTrashElement.style.top = Math.round(Math.random() * 90) + '%';
            newTrashElement.firstChild.setAttribute('id', 'TRASH_IMAGE' + i);
            GAME_CONTAINER.appendChild(newTrashElement);
        }
    }

    function clearAllTrash() {
        while (GAME_CONTAINER.firstChild) {
            GAME_CONTAINER.removeChild(GAME_CONTAINER.firstChild);
        }
    }

    function allowDrop(event) {
        event.preventDefault();
    }

    function drag(event) {
        event.dataTransfer.setData("dragged-id", event.target.id);
    }

    function drop(event) {
        event.preventDefault();
        var data = event.dataTransfer.getData("dragged-id");
        var trashDiv = document.getElementById(data).parentElement;

        GAME_CONTAINER.removeChild(trashDiv);
        closeCan();
        currentNumberOfTrash--;
        if (currentNumberOfTrash == 0) {
            endGame();
        }
    }

    return {
        startGame: startGame,
        setTrashcanAttributes: setTrashcanAttributes,
        drag: drag,
        drop: drop,
        allowDrop: allowDrop,
        closeCan: closeCan
    }
})();