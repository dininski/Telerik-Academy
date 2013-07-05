/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:40643/api/";
    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }

            this.attachUIEventHandlers(selector);
        },
        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.loginForm()
            $(selector).html(loginFormHtml);
        },
        loadGameUI: function (selector) {
            var allMessages = this.persister.messages.all();
            var unreadMessages = this.persister.messages.unread();

            var list =
				ui.gameUI(this.persister.nickname(), allMessages, unreadMessages);

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

            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    self.loadGameUI(selector);
                }, function () {
                    wrapper.html("oh no..");
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
                }, function () { });

                return false;
            });
            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                });
            });

            wrapper.on("click", "#open-games-container a", function () {
                $("#game-join-inputs").remove();
                var html =
					'<div id="game-join-inputs">' +
						'Number: <input type="text" id="tb-game-number"/>' +
						'Password: <input type="text" id="tb-game-pass"/>' +
						'<button id="btn-join-game">join</button>' +
					'</div>';
                $(this).after(html);
            });
            wrapper.on("click", "#btn-join-game", function () {
                var game = {
                    number: $("#tb-game-number").val(),
                    gameId: $(this).parents("li").first().data("game-id")
                };

                var password = $("#tb-game-pass").val();

                if (password) {
                    game.password = password;
                }
                self.persister.game.join(game);
            });
            wrapper.on("click", "#btn-create-game", function () {
                var game = {
                    title: $("#tb-create-title").val(),
                    number: $("#tb-create-number").val(),
                }
                var password = $("#tb-create-pass").val();
                if (password) {
                    game.password = password;
                }
                self.persister.game.create(game);
            });

            wrapper.on("click", ".active-games .in-progress", function () {
                self.loadGame(selector, $(this).parent().data("game-id"));
            });
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