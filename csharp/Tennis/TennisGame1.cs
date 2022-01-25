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
            if (player1Score == player2Score) 
                return GetScoreForEqual();
            if (player1Score >= 4 || player2Score >= 4) 
                return GetScoreForLateGame();
            return GetScoreForEarlyGame();
        }

        private string GetScoreForEarlyGame()
        {
            return $"{ConvertScoreToText(player1Score)}-{ConvertScoreToText(player2Score)}";
        }

        private static string ConvertScoreToText(int tempScore)
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

