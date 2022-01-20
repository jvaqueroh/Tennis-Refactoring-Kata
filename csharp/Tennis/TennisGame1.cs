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
                score = GetScoreWhenEarlyGame();
            }
            return score;
        }

        private string GetScoreWhenEarlyGame()
        {
            string score = "";
            score += ConvertoScoreToText(player1Score);
            score += "-";
            score += ConvertoScoreToText(player2Score);
            
            return score;
        }

        private static string ConvertoScoreToText(int tempScore)
        {
            if (tempScore == 0) return "Love";
            if (tempScore == 1) return "Fifteen";
            if (tempScore == 2) return "Thirty";
            return "Forty";
        }

        private string GetScoreForLateGame()
        {
            var minusResult = player1Score - player2Score;
            if (minusResult == 1)  return "Advantage player1";
            if (minusResult == -1) return "Advantage player2";
            if (minusResult >= 2)  return "Win for player1";
            return "Win for player2";
        }

        private string GetScoreForEqual()
        {
            if (player1Score == 0) return "Love-All";
            if (player1Score == 1) return "Fifteen-All";
            if (player1Score == 2) return "Thirty-All";
            return "Deuce";
        }
    }
}

