/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:22954/api/";
    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        listenForNewMessages: function () {
            var self = this;
            setInterval(function () {
                self.persister.messages.unread(function (data) {
                    if (data.length > 0) {
                        var message = "";
                        for (var i = 0; i < data.length; i++) {
                            message += data[i].text + '</br>';
                        }

                        ui.setFlash(message);
                    }
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            }, 1000);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
                this.listenForNewMessages();
            }
            else {
                this.loadLoginFormUI(selector);
            }

            this.attachUIEventHandlers(selector);
        },
        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.loginForm()
            $(selector).html(loginFormHtml);
            ui.setFlash("Please log in");
        },
        loadGameUI: function (selector) {

            var list =
				ui.gameUI(this.persister.nickname());

            $(selector).html(list);

            this.persister.game.open(function (games) {
                var list = ui.openGamesList(games);
                $(selector + " #open-games")
					.html(list);
            });

            this.persister.game.myActive(function (games) {
                var list = ui.activeGamesList(games);
                $(selector + " #active-games")
					.html(list);
            });
        },
        loadGame: function (selector, gameId) {
            this.persister.game.state(gameId, function (gameState) {
                var gameHtml = ui.gameState(gameState);
                $(selector + " #game-holder").html(gameHtml)
            });
        },
        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-show-login", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#login-form").show();
                wrapper.find("#register-form").hide();
            });

            wrapper.on("click", "#btn-show-register", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#register-form").show();
                wrapper.find("#login-form").hide();
            });

            wrapper.on("click", "#btn-scores", function () {
                self.persister.user.scores(function (data) {
                    var html = ui.displayAllScores(data);

                    $(selector).children().not('nav').remove();

                    $('nav').after(html);
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            });

            wrapper.on("click", "#btn-home", function () {
                self.loadUI(selector);
            });

            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    self.loadGameUI(selector);
                    this.listenForNewMessages()
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
                return false;
            });

            wrapper.on("click", "#btn-register", function () {
                var newUser = {
                    username: $(selector + " #tb-register-username").val(),
                    nickname: $(selector + " #tb-register-nickname").val(),
                    password: $(selector + " #tb-register-password").val(),
                }

                self.persister.user.register(newUser, function (data) {
                    self.loadGameUI(selector);
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });

                return false;
            });

            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                    ui.setFlash('Successfully logged out');
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            });

            wrapper.on("click", "#open-games-container a", function () {
                $("#game-join-inputs").remove();
                var html =
					'<div id="game-join-inputs">' +
						'<button id="btn-join-game" class="btn btn-success">Join</button>' +
					'</div>';

                $(this).after(html);
            });

            wrapper.on("click", "#btn-join-game", function () {
                var game = {
                    id: $(this).parents("li").first().data("game-id")
                };

                self.persister.game.join(game);

                setTimeout(function () {
                    self.loadUI(selector)
                }, 100);
            });

            wrapper.on("click", "#btn-create-game", function () {
                var game = {
                    title: $("#tb-create-title").val(),
                }

                var password = $("#tb-create-pass").val();

                if (password) {
                    game.password = password;
                }

                self.persister.game.create(game, function (data) {
                    ui.setFlash("Successfully created game");
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });

                setTimeout(function () {
                    self.loadGameUI(selector);
                }, 100);
            });

            wrapper.on("click", ".active-games .in-progress", function () {
                return false;
            });

            wrapper.on("click", ".full", function () {
                $('#start-game-btn').remove();
                $(this).siblings('button').remove();
                if ($(this).parent().data('game-owner').toString() === self.persister.nickname().toString()) {
                    var html = '<button id="start-game-btn" class="btn btn-success">Start game</button>';
                }

                $(this).after(html);

                return false;
            });

            wrapper.on('click', '.blue', function () {
                if (self.persister.nickname() === '') {

                }

                return false;
            });

            wrapper.on("click", "#start-game-btn", function () {
                var game = {
                    id: $(this).parents("li").first().data("game-id")
                }

                self.persister.game.start(game);
                setTimeout(function () {
                    self.loadUI(selector);
                }, 100);

                return false;
            });

            wrapper.on("click", "#btn-all-messages", function () {
                self.persister.messages.all(function (data) {
                    var messages = ui.displayAllMessages(data);
                    $(selector).children().not('#menu').remove();

                    $('nav').after(messages);
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            });

            wrapper.on("click", "#btn-active-games", function () {
                self.persister.game.myActive(function (data) {
                    var activeGames = ui.getActiveGames(data);
                    $(selector).children().not('#menu').remove();
                    $('nav').after(activeGames);
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            });

            wrapper.on("click", 'li.in-progress', function () {
                var gameId = $(this).data("game-id");

                self.persister.game.state(gameId, function (data) {
                    var game = ui.generateGame(data);
                    $(selector).children().not('#menu').remove();
                    $('nav').after(game);
                    buildTable(data);

                    enableSelection(data);
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            });

            var enableSelection = function (data) {
                var currentPlayerTurn = data.inTurn;
                var currentPlayerName = '';

                if (currentPlayerTurn === 'red') {
                    currentPlayerName = data.red.nickname;
                } else {
                    currentPlayerName = data.blue.nickname;
                }
                if (self.persister.nickname() === currentPlayerName) {
                    $('.' + currentPlayerTurn).on('click', function () {
                        $('.selected').removeClass('selected');
                        $(this).addClass('selected');

                        var currentCol = $(this).data('cell-col');
                        var currentRow = $(this).data('cell-row');
                        
                        return false;
                    });
                }
            }

            wrapper.on("click", 'a.in-progress', function () {
                var gameId = $(this).parent().data("game-id");

                self.persister.game.state(gameId, function (data) {

                    var game = ui.generateGame(data);
                    $(selector).children().not('#menu').remove();
                    $('nav').after(game);

                    buildTable(data);
                    enableSelection(data);
                }, function (data) {
                    ui.setFlash(data.responseJSON.Message.toString(), "err");
                });
            });

            wrapper.on('click', '.blue', function () {

            });

            var getPlayerMove = function (data) {

            }

            var buildTable = function (gameData) {
                var blueUnits = gameData.blue.units;

                var redUnits = gameData.red.units;
                var playingField = $('#playingField');

                for (var i = 0; i < blueUnits.length; i++) {
                    var currentRow = +blueUnits[i].position.x;
                    var currentCol = +blueUnits[i].position.y;
                    $('#playingField .row-' + currentCol + " .col-" + currentRow)
                        .css('background', 'blue')
                        .addClass(blueUnits[i].type)
                        .addClass('blue')
                        .attr('data-element-id', blueUnits[i].id)
                        .text(blueUnits[i].type[0]);
                }

                for (var i = 0; i < redUnits.length; i++) {
                    var currentRow = +redUnits[i].position.x;
                    var currentCol = +redUnits[i].position.y;
                    $('#playingField .row-' + currentCol + " .col-" + currentRow)
                        .css('background', 'red').addClass(redUnits[i].type)
                        .addClass('red')
                        .attr('data-element-id', redUnits[i].id)
                        .text(redUnits[i].type[0]);
                }
            }
        }
    });
    return {
        get: function () {
            return new Controller();
        }
    }
}());

$(function () {
    var controller = controllers.get();
    controller.loadUI("#content");
});