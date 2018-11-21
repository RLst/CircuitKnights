// Duckbike
// Tony Le
// 1 Nov 2018

namespace CircuitKnights
{

    public interface IInput
    {
        float LeftAxisX { get; }
        float LanceAxisY { get; }

        float LeanLeftAxis { get; }
        float LeanRightAxis { get; }

        float Accel { get; }
        float Decel { get; }

        bool RightBumper { get; }
        bool LeftBumper { get; }

        bool A { get; }
        bool B { get; }
        bool X { get; }
        bool Y { get; }

        bool Up { get; }
        bool Down { get; }
        bool Left { get; }
        bool Right { get; }

        // bool OK { get; }
        // bool Back { get; }
        void ReadInput();

    }

}