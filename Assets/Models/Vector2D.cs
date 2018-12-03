namespace Models {

  public class Vector2D {
    public readonly int X;
    public readonly int Y;

    public Vector2D(int x, int y) {
      X = x;
      Y = y;
    }

    public Vector2D Add(Vector2D other) {
      return new Vector2D(X + other.X, Y + other.Y);
    }

    public static Vector2D Zero {
      get { return new Vector2D(0, 0); }
    }

    public static Vector2D Up {
      get { return new Vector2D(0, 1); }
    }

    public static Vector2D UpRight {
      get { return new Vector2D(1, 1); }
    }
    
    public static Vector2D Right {
      get { return new Vector2D(1, 0); }
    }

    public static Vector2D DownRight {
      get { return new Vector2D(1, -1); }
    }

    public static Vector2D Down {
      get { return new Vector2D(0, -1); }
    }

    public static Vector2D DownLeft {
      get { return new Vector2D(-1, -1); }
    }

    public static Vector2D Left {
      get { return new Vector2D(-1, 0); }
    }

    public static Vector2D UpLeft {
      get { return new Vector2D(-1, 1); }
    }

    public override bool Equals(object other) {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return other.GetType() == GetType() && Equals((Vector2D) other);
    }

    private bool Equals(Vector2D other) {
      return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() {
      unchecked {
        return (X * 397) ^ Y;
      }
    }
  }
}