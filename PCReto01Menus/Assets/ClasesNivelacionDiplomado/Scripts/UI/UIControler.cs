using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{
    UIDocument menu;


    //Menu Principal
    Button hangerButton;
    Button PlayButton;
    Button OptionsBtn;
    Button ExitBtn;
    VisualElement Home;
   

    //propiedades conteJugar
    VisualElement contenJugar;
    Button btnNivel1;
    Button btnNivel2;
    Button btnNivel3;
    Button btnVolverNivelJuego;
    public static int nivelSeleccionado;

    //Propiedades Hanger
    VisualElement Hanger;
    Button btn01Hanger;
    Button btn02Hanger;
    Button btn03Hanger;
    Label nameObjectHanger;
    ProgressBar barStatistics1;
    ProgressBar barStatistics2;
    ProgressBar barStatistics3;
    Button backButton;

    //propiedades contenOpcion
    VisualElement contenOpcion;
    Button backButtonOpcion;
    Slider volumeSlider;

    [Header("Music Button")]
    [SerializeField] private Sprite mutedSprite;
    [SerializeField] private Sprite unmutedSprite;
    private Button muteButton;
    private bool muted;

    private void OnEnable()
    {
        menu = GetComponent<UIDocument>();

        VisualElement root = menu.rootVisualElement;
        
        //Menu Principal
        hangerButton = root.Q<Button>("hangerButton");
        PlayButton = root.Q<Button>("PlayButton");
        OptionsBtn = root.Q<Button>("OptionsBtn");
        ExitBtn = root.Q<Button>("ExitBtn");
        Home = root.Q<VisualElement>("Home");

        //propuedades contenJugar
        contenJugar = root.Q<VisualElement>("contenJugar");
        btnNivel1 = root.Q<Button>("btnNivel1");
        btnNivel2 = root.Q<Button>("btnNivel2");
        btnNivel3 = root.Q<Button>("btnNivel3");
        btnVolverNivelJuego = root.Q<Button>("btnVolverNivelJuego");

        //Propiedades Hanger
        Hanger = root.Q<VisualElement>("contenHanger"); 
        btn01Hanger = root.Q<Button>("Btn01Hanger");
        btn02Hanger = root.Q<Button>("Btn02Hanger");
        btn03Hanger = root.Q<Button>("Btn03Hanger");
        nameObjectHanger = root.Q<Label>("NameObjectHanger");
        barStatistics1 = root.Q<ProgressBar>("BarStatistics1");
        barStatistics2 = root.Q<ProgressBar>("BarStatistics2");
        barStatistics3 = root.Q<ProgressBar>("BarStatistics3");
        backButton = root.Q<Button>("BackButton");


        //Propiedades contenOpcion
        contenOpcion = root.Q<VisualElement>("contenOpcion");
        backButtonOpcion = root.Q<Button>("backButtonOpcion");
        muteButton = root.Q<Button>("MuteButton");
        volumeSlider = root.Q<Slider>("VolumeSlider");



        //Callbacks
        hangerButton.RegisterCallback<ClickEvent>(HangerOpen);
        btn01Hanger.RegisterCallback<ClickEvent, int>(Selection, 1);
        btn02Hanger.RegisterCallback<ClickEvent, int>(Selection, 2);
        btn03Hanger.RegisterCallback<ClickEvent, int>(Selection, 3);
        backButton.RegisterCallback<ClickEvent>(CloseHanger);

        PlayButton.RegisterCallback<ClickEvent>(contenJugarOpen);
        btnVolverNivelJuego.RegisterCallback<ClickEvent>(ClosecontenJugar);

        OptionsBtn.RegisterCallback<ClickEvent>(contenOpcionOpen);
        backButtonOpcion.RegisterCallback<ClickEvent>(ClosecontenOpcion);

        ExitBtn.clicked += ExitButttonPressed;
        muteButton.RegisterCallback<ClickEvent>(MuteButtonPressed);
        volumeSlider.RegisterValueChangedCallback(OnVolumeSliderValueChanged);


        btnNivel1.RegisterCallback<ClickEvent, int>(PlayGame, 1);
        btnNivel2.RegisterCallback<ClickEvent, int>(PlayGame, 2);
        btnNivel3.RegisterCallback<ClickEvent, int>(PlayGame, 3);


    }

    public void contenOpcionOpen(ClickEvent evnt)
    {
        Debug.Log("se va activar ventana de opciones.");
        contenOpcion.style.display = DisplayStyle.Flex;

        contenJugar.RemoveFromClassList("contenJugar-Active");
        Hanger.RemoveFromClassList("contenHanger-Active");
        Home.style.display = DisplayStyle.None;

    }

    public void ClosecontenOpcion(ClickEvent evnt)
    {
        Debug.Log("se va cerrar ventana de opciones.");
        contenOpcion.style.display = DisplayStyle.None;
        Home.style.display = DisplayStyle.Flex;

    }


    public void contenJugarOpen(ClickEvent evnt)
    {
        Debug.Log("se va activar ventana de nivel juego.");
        contenJugar.AddToClassList("contenJugar-Active");

        contenOpcion.style.display = DisplayStyle.None;
        Hanger.RemoveFromClassList("contenHanger-Active");
        Home.style.display = DisplayStyle.None;

    }

    public void ClosecontenJugar(ClickEvent evnt)
    {
        Debug.Log("se va cerrar ventana de nivel juego.");
        contenJugar.RemoveFromClassList("contenJugar-Active");
        Home.style.display = DisplayStyle.Flex;

    }

    public void PlayGame(ClickEvent evnt, int nivel)
    {
        switch (nivel)
        {
            case 1:
                nivelSeleccionado = 1;
                Debug.Log("inicia Nivel sencillo");
                break;
            case 2:
                nivelSeleccionado = 2;
                Debug.Log("inicia Nivel Medio");
                break;
            case 3:
                nivelSeleccionado = 3;
                Debug.Log("inicia Nivel Complicado");
                break;
        }
        SceneManager.LoadScene("Scene1");

    }

        public void HangerOpen(ClickEvent evnt)
    {
        Debug.Log("se va activar ventana de personajes.");
        Hanger.AddToClassList("contenHanger-Active");

        contenOpcion.style.display = DisplayStyle.None;
        contenJugar.RemoveFromClassList("contenJugar-Active");
        Home.style.display = DisplayStyle.None;
    }



    public void Selection(ClickEvent evnt, int model)
    {
        switch (model)
        {
            case 1:
                nameObjectHanger.text = "Gato Blanco";
                barStatistics1.lowValue = 50;
                barStatistics2.lowValue = 30;
                barStatistics3.lowValue = 45;
                break;
            case 2:
                nameObjectHanger.text = "Gato Amarillo";
                barStatistics1.lowValue = 60;
                barStatistics2.lowValue = 20;
                barStatistics3.lowValue = 30;
                break;
            case 3:
                nameObjectHanger.text = "Gato negro";
                barStatistics1.lowValue = 70;
                barStatistics2.lowValue = 15;
                barStatistics3.lowValue = 40;
                break;
        }
    }

    public void CloseHanger(ClickEvent evnt)
    {
        Debug.Log("se va cerrar venta personajes.");
        Hanger.RemoveFromClassList("contenHanger-Active");
        Home.style.display = DisplayStyle.Flex;
    }

    public void ExitButttonPressed()
    {
        Debug.Log("Sali del juego");
        Application.Quit();
    }

    public void OnVolumeSliderValueChanged(ChangeEvent<float> evnt)
    {
        // Obtener el valor del Slider (entre 0 y 1)
        float volumeValue = evnt.newValue;

        // Actualizar el volumen del AudioListener
        AudioListener.volume = volumeValue;
    }

    public void MuteButtonPressed(ClickEvent evnt)
    {
        muted = !muted;
        var bg = muteButton.style.backgroundImage;
        bg.value = Background.FromSprite(muted ? mutedSprite : unmutedSprite);
        muteButton.style.backgroundImage = bg;
        AudioListener.volume = muted ? 0 : 1;
    }
}
