namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;

        public TennisGame1()
        {
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            if (player1Score == player2Score)
            {
                score = GetScoreForEqual();
            }
            else if (player1Score >= 4 || player2Score >= 4)
            {
                score = GetScoreForLateGame();
            }
            else
            {
                score = GetScoreWhenEarlyGame(score);
            }
            return score;
        }

        private string GetScoreWhenEarlyGame(string score)
        {
            for (var i = 1; i < 3; i++)
            {
                var tempScore = 0;
                if (i == 1) tempScore = player1Score;
                else
                {
                    score += "-";
                    tempScore = player2Score;
                }

                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        private string GetScoreForLateGame()
        {
            string score;
            var minusResult = player1Score - player2Score;
            switch (minusResult)
            {
                case 1:
                    score = "Advantage player1";
                    break;
                case -1:
                    score = "Advantage player2";
                    break;
                default:
                {
                    if (minusResult >= 2) score = "Win for player1";
                    else score = "Win for player2";
                    break;
                }
            }
            return score;
        }

        private string GetScoreForEqual()
        {
            string score;
            switch (player1Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}

