namespace SuperBall
{
    public class PlayerStats
    {
        private float _curentSpeed;
        private float _lockMileage;
        private float _tickMileage;

        public float Speed()
        {
            return _curentSpeed;
        }

        public void SetSpeed(float spped)
        {
            _curentSpeed = spped;
        }

        public void AddLockMileage(float mileage)
        {
            _lockMileage += mileage;
        }

        public void TickMileage(float mileage)
        {
            _tickMileage = mileage;
        }

        public float TickMileage()
        {
            return _tickMileage;
        }

        public float Mileage()
        {
            return _lockMileage + _tickMileage;
        }
    }
}