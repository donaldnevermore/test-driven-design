namespace Frame {
    public class Frame {
        public Frame() {
            Score = 0;
        }

        public int Score { get; private set; }

        public void Add(int pins) {
            Score += pins;
        }
    }
}
