namespace Tennis 
{

    public class TennisGame1 : ITennisGame {
        private readonly PlayerScore player1Score;
        private readonly PlayerScore player2Score;
        private readonly Scoreboard scoreboard;

        public TennisGame1() {
            player1Score = new PlayerScore();
            player2Score = new PlayerScore();
            scoreboard = new Scoreboard(player1Score, player2Score);
        }

        public void WonPoint(string playerName) {
            if (playerName == "player1")
                player1Score.AddPoint();
            else
                player2Score.AddPoint();
        }

        public string GetScore()
        {
            return scoreboard.GetScore();
        }
    }
    public class Scoreboard
    {
        private readonly PlayerScore player1Score;
        private readonly PlayerScore player2Score;

        public Scoreboard(PlayerScore player1Score, PlayerScore player2Score)
        {
            this.player2Score = player2Score;
            this.player1Score = player1Score;
        }

        public string GetScore()
        {
            if (player1Score.Equals(player2Score))
                return player1Score.GetScoreForEqual();
            if (player1Score.IsInLateGame() || player2Score.IsInLateGame())
                return player1Score.GetScoreForLateGame(player2Score);
            return player1Score.GetScoreForEarlyGame(player2Score);
        }
    }

    public class PlayerScore
    {
        private const int MinLateGamePoints = 4;
        private int value = 0;

        public string GetScoreForEarlyGame(PlayerScore other)
        {
            return $"{ConvertScoreToText(value)}-{ConvertScoreToText(other.value)}";
        }

        public string GetScoreForLateGame(PlayerScore other)
        {
            var minusResult = value - other.value;
            if (minusResult == 1)  return "Advantage player1";
            if (minusResult == -1) return "Advantage player2";
            if (minusResult >= 2)  return "Win for player1";
            return "Win for player2";
        }

        public string GetScoreForEqual()
        {
            if (value == 0) return "Love-All";
            if (value == 1) return "Fifteen-All";
            if (value == 2) return "Thirty-All";
            return "Deuce";
        }

        public void AddPoint()
        {
            this.value += 1;
        }

        public bool Equals(PlayerScore other)
        {
            return this.value == other.value;
        }

        public bool IsInLateGame()
        {
            return this.value >= MinLateGamePoints;
        }

        private static string ConvertScoreToText(int tempScore) {
            if (tempScore == 0) return "Love";
            if (tempScore == 1) return "Fifteen";
            if (tempScore == 2) return "Thirty";
            return "Forty";
        }
    }
}

