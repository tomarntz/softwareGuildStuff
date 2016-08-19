$(document)
    .ready(function() {
        $('#playGame')
            .on('click',
                function playGame() {
                    var player = {
                        StartingBet: $("#amount").val(),
                        TimesRolled: 0,
                        MaxWinnings: 0,
                        MaxWinningsRolled: 0
                    };

                    var currentWinnings = player.StartingBet;
                    player.MaxWinnings = currentWinnings;

                    do {
                        var die1 = Math.floor(Math.random() * 10 % 6 + 1);
                        var die2 = Math.floor(Math.random() * 10 % 6 + 1);

                        var sum = die2 + die1;

                        player.TimesRolled++;

                        if (sum === 7) {
                            currentWinnings += 4;

                            if (player.MaxWinnings < currentWinnings) {
                                player.MaxWinnings = currentWinnings;
                                player.MaxWinningsRolled = player.TimesRolled;
                            }
                        } else {
                            currentWinnings -= 1;
                        }
                    } while (currentWinnings > 0);


                    console.log("Starting Bet: " + player.StartingBet);
                    console.log("Times Played :" + player.TimesRolled);
                    console.log("Max Winning: " + player.MaxWinnings);
                    console.log("Max Rolled on: " + player.MaxWinningsRolled);

                    $("#StartingBet").val(player.StartingBet);
                    $("#TotalRolls").val(player.TimesRolled);
                    $("#MaxWinnings").val(player.MaxWinnings);
                    $("#MaxRolled").val(player.MaxWinningsRolled);

                    $("#resultsTable").show();
                }
            );
        $("#playAgain")
            .on("click",
                function() {
                    $("#StartingBet").val("");
                    $("#TotalRolls").val("");
                    $("#MaxWinnings").val("");
                    $("#MaxRolled").val("");

                    $("#resultsTable").hide();
                });

        $("#resultsTable").hide();
    });