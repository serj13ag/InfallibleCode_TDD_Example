using System.Collections.Generic;
using System.Linq;

public class HeartContainer
{
    private readonly List<Heart> _hearts;

    public HeartContainer(List<Heart> hearts)
    {
        _hearts = hearts;
    }

    public void Replenish(int heartPieces)
    {
        // Before refactor

        /*
        var numberOfHeartPiecesRemaining = numberOfHeartPieces;
        foreach (var heart in _hearts)
        {
            if (numberOfHeartPiecesRemaining < heart.EmptyHeartPieces)
            {
                heart.Replenish(numberOfHeartPiecesRemaining);
                break;
            }

            numberOfHeartPiecesRemaining -= Heart.HeartPiecesPerHeart - heart.FilledHeartPieces;
            heart.Replenish(numberOfHeartPieces);
                    
            if (numberOfHeartPiecesRemaining <= 0) break;
        }
        */

        foreach (var heart in _hearts)
        {
            var toReplenish = heartPieces < heart.EmptyHeartPieces
                ? heartPieces
                : heart.EmptyHeartPieces;
            heartPieces -= heart.EmptyHeartPieces;
            heart.Replenish(toReplenish);

            if (heartPieces <= 0) break;
        }
    }

    public void Deplete(int heartPieces)
    {
        foreach (var heart in _hearts.AsEnumerable().Reverse())
        {
            var toDeplete = heartPieces < heart.FilledHeartPieces
                ? heartPieces
                : heart.FilledHeartPieces;
            heartPieces -= heart.FilledHeartPieces;
            heart.Deplete(toDeplete);

            if (heartPieces <= 0) break;
        }
    }
}
