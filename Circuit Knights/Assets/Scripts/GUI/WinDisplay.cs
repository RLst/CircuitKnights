using UnityEngine;

//Brent D'Auria

namespace CircuitKnights
{
    public class WinDisplay : MonoBehaviour {

        //GameSettings.Instance.isDraw;

        // publi bool PlayerOneWins;
        // bool PlayerTwoWins;
        [SerializeField] GameObject DrawCanvas;
        [SerializeField] GameObject PlayerOneWins;
        [SerializeField] GameObject PlayerTwoWins;

        private void Update()
        {
            DisplayWinner();
        }


        public void DisplayWinner()
        {
            if (GameSettings.Instance.isDraw())
            {
                DrawCanvas.SetActive(true);
                PlayerTwoWins.SetActive(false);
                PlayerOneWins.SetActive(false);
            }
            else if(GameSettings.Instance.PlayerOne.isDead)
            {
                DrawCanvas.SetActive(false);
                PlayerTwoWins.SetActive(false);
                PlayerOneWins.SetActive(true);
            }
            else if (GameSettings.Instance.PlayerTwo.isDead)
            {
                DrawCanvas.SetActive(false);
                PlayerTwoWins.SetActive(true);
                PlayerOneWins.SetActive(false);
            }
        }
    }
}
