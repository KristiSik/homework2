namespace ConsoleApplication1
{
    public enum State
    {
        Dead = 0,
        Sick = 1,
        Hungry = 2,
        Satisfied = 3
    }
    public abstract class Animal
    {
        protected int StartHealth;
        protected int _health;
        private State _state;
        protected string _name;
        public Animal()
        {
            _state = State.Satisfied;
        }
        public State State
        {
            get { return _state; }
        }
        public string Name
        {
            get { return _name; }
        }
        public int Health
        {
            get { return _health; }
        }
        public void Feed()
        {
            _state = State.Satisfied;
        }
        public void WorsenState()
        {
            if (_state == State.Sick)
            {
                _health--;
                if (Health == 0)
                {
                    _state = State.Dead;
                }
            }
            else
            {
                if (_state > 0)
                {
                    _state--;
                }
            }
        }
        public void ImproveState()
        {
            if (_state != State.Satisfied)
            {
                _state++;
            }
        }
        public void Heal()
        {
            if (Health < StartHealth)
            {
                _health++;
            }
        }
    }
}
