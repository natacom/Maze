using System.Runtime.InteropServices;

class libMaze
{
    [DllImport("libMaze.dll", EntryPoint = "Generate", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Generate(int rowNum, int columnNum);

    [DllImport("libMaze.dll", EntryPoint = "ExistTopWall", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool ExistTopWall(int row, int column);

    [DllImport("libMaze.dll", EntryPoint = "ExistRightWall", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool ExistRightWall(int row, int column);

    [DllImport("libMaze.dll", EntryPoint = "ExistBottomWall", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool ExistBottomWall(int row, int column);

    [DllImport("libMaze.dll", EntryPoint = "ExistLeftWall", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool ExistLeftWall(int row, int column);
}
