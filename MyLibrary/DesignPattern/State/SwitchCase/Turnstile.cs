namespace DesignPattern.State.SwitchCase
{
    public enum State { LOCKED, UNLOCKED }

    public enum Event { COIN, PASS }

    public class Turnstile
    {
        internal State state = State.LOCKED;

        private TurnstileController turnstileController;

        public Turnstile(TurnstileController action)
        {
            turnstileController = action;
        }

        public void HandleEvent(Event e)
        {
            switch (state)
            {
                case State.LOCKED:
                    switch (e)
                    {
                        case Event.COIN:
                            state = State.UNLOCKED;
                            turnstileController.Unlock();
                            break;
                        case Event.PASS:
                            turnstileController.Alarm();
                            break;
                    }
                    break;
                case State.UNLOCKED:
                    switch (e)
                    {
                        case Event.COIN:
                            turnstileController.Thankyou();
                            break;
                        case Event.PASS:
                            state = State.LOCKED;
                            turnstileController.Lock();
                            break;
                    }
                    break;
            }
        }
    }
}
