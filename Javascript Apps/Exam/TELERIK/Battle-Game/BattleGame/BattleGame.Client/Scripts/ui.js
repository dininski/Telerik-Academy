/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-2.0.2.intellisense.js" />
var ui = (function () {

    function buildLoginForm() {
        var html =
            '<div id="login-form-holder">' +
				'<form>' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="password" id="tb-login-password"><br />' +
						'<button id="btn-login" class="btn btn-success" style="margin: 20px;">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="password" id="tb-register-password"><br />' +
						'<button id="btn-register" class="btn btn-success" style="margin: 20px;">Register</button>' +
					'</div>' +
					'<a href="#" id="btn-show-login" class="btn selected">Login</a>' +
					'<a href="#" id="btn-show-register" class="btn">Register</a>' +
				'</form>' +
            '</div>';
        return html;
    }

    function buildGameUI(nickname) {
        var html = '<nav id="menu">' +
        '<div style="margin: 20px; text-align: right"><span id="user-nickname" style="margin: 20px;">' +
				nickname +
		'</span>' +
		'<button id="btn-home" class="btn btn-success" style="margin-right: 10px;">Home</button>' +
        '<button id="btn-active-games" class="btn btn-success" style="margin-right: 10px;">My active games</button>' +
		'<button id="btn-all-messages" class="btn btn-success" style="margin-right: 10px;">All messages</button>' +
		'<button id="btn-scores" class="btn btn-success" style="margin-right: 10px;">Scores</button>' +
        '<button id="btn-logout" class="btn btn-info">Logout</button></div><br/>' +
        '</nav>' +
		'<div id="create-game-holder" style="width: 100%; text-align: right;">' +
			'Title: <input type="text" id="tb-create-title"  style="margin: 0; margin-right: 10px;"/>' +
			'<button id="btn-create-game" class="btn">Create</button>' +
		'</div>' +
		'<div id="open-games-container">' +
			'<h2>Open</h2>' +
			'<div id="open-games"></div>' +
		'</div>' +
		'<div id="active-games-container">' +
			'<h2>Active</h2>' +
			'<div id="active-games"></div>' +
		'</div>' +
		'<div id="game-holder">' +
		'</div>';


        return html;
    }

    function displayAllScores(data) {
        var html = "<ol style='text-align: left'>";
        for (var i = 0; i < data.length; i++) {
            html += "<li>" + data[i].nickname + " " + data[i].score + "</li>";
        }

        html += "</ol>";

        return html;
    }

    function displayAllMessages(messages) {
        var html = "<ul class='unstyled'>";

        for (var i = 0; i < messages.length; i++) {
            html += "<li>" + messages[i].text + "</li>";
        }

        html += "</ul>";

        return html;
    }

    function buildOpenGamesList(games) {
        var list = '<ul class="game-list open-games">';
        for (var i = 0; i < games.length; i++) {
            var game = games[i];
            list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" >' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
        }
        list += "</ul>";
        return list;
    }

    function buildActiveGamesList(games) {
        var gamesList = Array.prototype.slice.call(games, 0);
        gamesList.sort(function (g1, g2) {
            if (g1.status == g2.status) {
                return g1.title > g2.title;
            }
            else {
                if (g1.status == "in-progress") {
                    return -1;
                }
            }
            return 1;
        });

        var list = '<ul class="game-list active-games">';
        for (var i = 0; i < gamesList.length; i++) {
            var game = gamesList[i];
            list +=
				'<li data-game-id="' + game.id + '" data-game-owner="' + game.creator + '">' +
					'<a href="#" class="' + game.status + '">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
        }
        list += "</ul>";
        return list;
    }

    function buildGuessTable(guesses) {
        var tableHtml =
			'<table border="1" cellspacing="0" cellpadding="5">' +
				'<tr>' +
					'<th>Number</th>' +
					'<th>Cows</th>' +
					'<th>Bulls</th>' +
				'</tr>';
        for (var i = 0; i < guesses.length; i++) {
            var guess = guesses[i];
            tableHtml +=
				'<tr>' +
					'<td>' +
						guess.number +
					'</td>' +
					'<td>' +
						guess.cows +
					'</td>' +
					'<td>' +
						guess.bulls +
					'</td>' +
				'</tr>';
        }
        tableHtml += '</table>';
        return tableHtml;
    }

    function buildGameState(gameState) {
        var html =
			'<div id="game-state" data-game-id="' + gameState.id + '">' +
				'<h2>' + gameState.title + '</h2>' +
				'<div id="blue-guesses" class="guess-holder">' +
					'<h3>' +
						gameState.blue + '\'s gueesses' +
					'</h3>' +
					buildGuessTable(gameState.blueGuesses) +
				'</div>' +
				'<div id="red-guesses" class="guess-holder">' +
					'<h3>' +
						gameState.red + '\'s gueesses' +
					'</h3>' +
					buildGuessTable(gameState.redGuesses) +
				'</div>' +
		'</div>';
        return html;
    }

    function getActiveGames(data) {
        var html = "<ul style='unstyled'>";
        for (var i = 0; i < data.length; i++) {
            html += "<li class='" + data[i].status + "' data-game-id='" + data[i].id + "'>" +
                "Game: " + data[i].title + " Creator: " + data[i].creator + " Game status: " + data[i].status + "</li>";
        }

        html += "</ul>";

        return html;
    }

    function generateGame(gameData) {
        var bluePlayer = gameData.blue.nickname;
        var redPlayer = gameData.red.nickname;
        var playerInTurn = "";

        if (gameData.inTurn === 'blue') {
            playerInTurn = bluePlayer;
        } else {
            playerInTurn = redPlayer;
        }

        var html = "<h2>" + gameData.title +
            "</h2><div>Player turn:" + playerInTurn + "</div>" +
            "<table id='playingField' style='margin-bottom: 40px'>";

        for (var row = 0; row < 9; row++) {
            html += "<tr class='row-" + row + "'>";

            for (var col = 0; col < 9; col++) {
                html += "<td class='col-" + col + "' data-cell-row='" + row + "' data-cell-col='" + col + "'></td>";
            }

            html += "</tr>";
        }

        html += "</table>";

        return html;
    }

    function setFlash(message, type) {
        var flashContainer = $('#flash-message');
        var flashColor;

        if (type === 'err') {
            flashColor = 'red';
        } else if (type === 'warn') {
            flashColor = 'yellow';
        } else {
            flashColor = 'green';
        }

        if (flashContainer.length == 0) {
            var html = '<div id="flash-message"' +
                'style="position:absolute; top: 10px; text-align: center; width: 200px; display: none;' +
                'left: 200px; border-radius: 10px; padding: 20px; background:' + flashColor + '; color: white"></div>';
            $('body').append(html);
        }

        flashContainer = $('#flash-message').html(message);
        flashContainer.css('background', flashColor);
        flashContainer.slideDown(1000, function () {
            var that = this;
            setTimeout(function () {
                $(that).slideUp(1000);
            }, 2000)
        });
    }

    return {
        gameUI: buildGameUI,
        openGamesList: buildOpenGamesList,
        loginForm: buildLoginForm,
        activeGamesList: buildActiveGamesList,
        gameState: buildGameState,
        setFlash: setFlash,
        displayAllMessages: displayAllMessages,
        displayAllScores: displayAllScores,
        getActiveGames: getActiveGames,
        generateGame: generateGame
    }

}());