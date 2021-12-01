using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionPersonaje : MonoBehaviour
{
    public Slider barraVida;
    public PersonajeDhifeus RealizandoAtaques;
    public AtaquesDhifeus GastandoMana;
    public Text ManaText;
    public Image imagenBarraVida;
    public Text indicadorSalud;
    public Text indicadorMana;
    public Image botellaVidaDefecto;
    public Sprite botellaVidaMaxima;
    public Sprite botellaVidaMitad;
    public Sprite botellaVidaVacia;
    public Image botellaManaDefecto;
    public Sprite botellaManaMaxima;
    public Sprite botellaManaMitad;
    public Sprite botellaManaVacia;
    public Slider barraMana;
    // Start is called before the first frame update
    void Start()
    {
        EstableciendoCaracteristicasJugador();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EstableciendoCaracteristicasJugador()
    {
        this.EstableciendoSalud(RealizandoAtaques.Salud, RealizandoAtaques.SaludMaxima);
        this.EstableciendoMana(RealizandoAtaques.Mana, RealizandoAtaques.ManaMaximo);
    }
    public void EstableciendoSalud(float Salud, float SaludMaxima)
    {
        this.indicadorSalud.text = $"{Mathf.RoundToInt(Salud)}/{Mathf.RoundToInt(SaludMaxima)}";
        float porcentaje = Salud / SaludMaxima;
        this.barraVida.value = porcentaje;
        if (porcentaje < 0.9f && porcentaje > 0.3f)
        {
            botellaVidaDefecto.GetComponent<Image>().sprite = botellaVidaMitad;
        }
        if (porcentaje < 0.3f)
        {
            botellaVidaDefecto.sprite = botellaVidaVacia;
        }
        if (porcentaje == 1)
        {
            botellaVidaDefecto.GetComponent<Image>().sprite = botellaVidaMaxima;
        }

    }
    public void EstableciendoMana(float Mana, float ManaMaximo)
    {
        this.indicadorMana.text = $"{Mathf.RoundToInt(Mana)}/{Mathf.RoundToInt(ManaMaximo)}";
        float porcentajeM = Mana / ManaMaximo;
        this.barraMana.value = porcentajeM;
        if (porcentajeM < 0.9f && porcentajeM > 0.3f)
        {
            botellaManaDefecto.GetComponent<Image>().sprite = botellaManaMitad;
        }
        if (porcentajeM < 0.3f)
        {
            botellaManaDefecto.sprite = botellaManaVacia;
        }
        if (porcentajeM == 1)
        {
            botellaManaDefecto.GetComponent<Image>().sprite = botellaManaMaxima;
        }

    }
}
