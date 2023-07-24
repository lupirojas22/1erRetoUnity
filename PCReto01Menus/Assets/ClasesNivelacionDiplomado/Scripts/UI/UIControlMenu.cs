using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIControlMenu : MonoBehaviour
{

    UIDocument menuEscena;

    //Menu Principal
    Button BtnPausa;
    Button BtnHome;
    Label totalVidas;

    //Menu pausa
    VisualElement contentPausa;
    Button BtnContinuar;
    Button btnClosed;
    Button BtnRegresar;
    Button BtnSalida;

    

    private void OnEnable()
    {
        menuEscena = GetComponent<UIDocument>();
        VisualElement root = menuEscena.rootVisualElement;

        //Menu Principal
        BtnPausa = root.Q<Button>("BtnPausa");
        BtnHome = root.Q<Button>("BtnHome");
        totalVidas = root.Q<Label>("totalVidas");

        //Menu pausa
        contentPausa = root.Q<VisualElement>("contentPausa");
        BtnContinuar = root.Q<Button>("BtnContinuar");
        btnClosed = root.Q<Button>("btnClosed");
        BtnRegresar = root.Q<Button>("BtnRegresar");
        BtnSalida = root.Q<Button>("BtnSalida");


        //Call Metodos
        BtnPausa.clicked += OpenBtnPausa;
        BtnContinuar.RegisterCallback<ClickEvent>(CerrarPausaMenu);
        btnClosed.RegisterCallback<ClickEvent>(CerrarPausaMenu);
        BtnHome.RegisterCallback<ClickEvent>(VolverHome);
        BtnRegresar.RegisterCallback<ClickEvent>(VolverHome);
        BtnSalida.RegisterCallback<ClickEvent>(ExitGame);
        NivelParaJugar(UIControler.nivelSeleccionado);

    }


    public void OpenBtnPausa()
    {
        Debug.Log("se va abrir menu pausa.");
        contentPausa.style.display = DisplayStyle.Flex;
    }

    public void CerrarPausaMenu(ClickEvent evnt)
    {
        Debug.Log("se va cerrar menu pausa.");
        contentPausa.style.display = DisplayStyle.None;
    }

    public void VolverHome(ClickEvent evnt)
    {
        Debug.Log("se menu principal.");
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame(ClickEvent evnt)
    {
        Debug.Log("Sali del juego");
        Application.Quit();
    }

    public void NivelParaJugar(int model)
    {
        switch (model)
        {
            case 1:
                totalVidas.text = "10";
                Debug.Log("Recibido Nivel sencillo");
                break;
            case 2:
                totalVidas.text = "5";
                Debug.Log("Recibido Nivel Medio");
                break;
            case 3:
                totalVidas.text = "3";
                Debug.Log("Recibido Nivel Complicado");
                break;
        }
    }

}
