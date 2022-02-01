using System;
using UnityEngine.UI;

public class Heart
{
    public static readonly int HeartPiecesPerHeart = 4;
    private const float FillPerHeartPiece = 0.25f;
    private readonly Image _image;

    public int FilledHeartPieces
    {
        get { return CalculateFilledHeartPieces(); }
    }

    public int EmptyHeartPieces
    {
        get { return HeartPiecesPerHeart - CalculateFilledHeartPieces(); }
    }

    public Heart(Image image)
    {
        _image = image;
    }

    public void Replenish(int numberOfHeartPices)
    {
        if (numberOfHeartPices < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive");

        _image.fillAmount += numberOfHeartPices * FillPerHeartPiece;
    }

    public void Deplete(int numberOfHeartPices)
    {
        if (numberOfHeartPices < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive");

        _image.fillAmount -= numberOfHeartPices * FillPerHeartPiece;
    }

    private int CalculateFilledHeartPieces()
    {
        return (int)(_image.fillAmount * HeartPiecesPerHeart);
    }
}