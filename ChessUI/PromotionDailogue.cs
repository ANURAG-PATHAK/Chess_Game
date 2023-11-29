using ChessUI.Properties;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

class PromotionDialogue : Form
{
    private PictureBox _pictureBoxBishop;
    private PictureBox _pictureBoxKnight;
    private PictureBox _pictureBoxQueen;
    private PictureBox _pictureBoxRook;
    private readonly bool _isLight;
    public string Piece { get; set; }
    public PromotionDialogue(bool isLight)
    {
        Piece = string.Empty;
        _isLight = isLight;
        Initialize();
    }
    private void Initialize()
    {
        string assetsFolderPath = Path.Combine(Application.StartupPath, "Assets");
        ClientSize = new Size(400, 100);
        CenterToParent();
        Text = Resources.Promotion;
        _pictureBoxBishop = new PictureBox
        {
            Location = new Point(0, 0),
            Size = new Size(100, 100),
            BackColor = _isLight ? Color.DarkGray : Color.WhiteSmoke,
            SizeMode = PictureBoxSizeMode.CenterImage,
            BorderStyle = BorderStyle.FixedSingle,
            ImageLocation = _isLight ? Path.Combine(assetsFolderPath, "LBishop.png") : Path.Combine(assetsFolderPath, "DBishop.png")
        };
        _pictureBoxKnight = new PictureBox
        {
            Location = new Point(100, 0),
            Size = new Size(100, 100),
            BackColor = _isLight ? Color.DarkGray : Color.WhiteSmoke,
            SizeMode = PictureBoxSizeMode.CenterImage,
            BorderStyle = BorderStyle.FixedSingle,
            ImageLocation = _isLight ? Path.Combine(assetsFolderPath, "LKnight.png") : Path.Combine(assetsFolderPath, "DKnight.png")
        };
        _pictureBoxQueen = new PictureBox
        {
            Location = new Point(200, 0),
            Size = new Size(100, 100),
            BackColor = _isLight ? Color.DarkGray : Color.WhiteSmoke,
            SizeMode = PictureBoxSizeMode.CenterImage,
            BorderStyle = BorderStyle.FixedSingle,
            ImageLocation = _isLight ? Path.Combine(assetsFolderPath, "LQueen.png") : Path.Combine(assetsFolderPath, "DQueen.png")
        };
        _pictureBoxRook = new PictureBox
        {
            Location = new Point(300, 0),
            Size = new Size(100, 100),
            BackColor = _isLight ? Color.DarkGray : Color.WhiteSmoke,
            SizeMode = PictureBoxSizeMode.CenterImage,
            BorderStyle = BorderStyle.FixedSingle,
            ImageLocation = _isLight ? Path.Combine(assetsFolderPath, "LRook.png") : Path.Combine(assetsFolderPath, "DRook.png")
        };
        _pictureBoxBishop.Click += (s, e) =>
        {
            Piece = "ChessLibrary.Bishop";
            Close();
        };
        _pictureBoxKnight.Click += (s, e) =>
        {
            Piece = "ChessLibrary.Knight";
            Close();
        };
        _pictureBoxQueen.Click += (s, e) =>
        {
            Piece = "ChessLibrary.Queen";
            Close();
        };
        _pictureBoxRook.Click += (s, e) =>
        {
            Piece = "ChessLibrary.Rook";
            Close();
        };
        Controls.Add(_pictureBoxRook);
        Controls.Add(_pictureBoxQueen);
        Controls.Add(_pictureBoxKnight);
        Controls.Add(_pictureBoxBishop);
    }
}