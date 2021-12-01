using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeDhifeus : MonoBehaviour
{
    public float SaludMaxima;
    public float Salud;
    public float Mana;
    public float ManaMaximo;
    public GestionPersonaje personaje;
    public ControlJugador Jugador;
    public GameObject disparoPsiquico;
    public GameObject disparoDoble;
    public GameObject disparoAire;
    public GameObject disparoFuego;
    public BalaFuego balaFuego;
    public BalaPsiquica balaPsiquica;
    public BalaDoble balaDoble;
    public BalaAire balaAire;
    public SpriteRenderer sprBalaFuego;
    public SpriteRenderer sprBalaPsiquica;
    public SpriteRenderer sprBalaDoble;
    public SpriteRenderer sprBalaAire;
    public PersonajeDhifeus estadisticasPersonaje;
    public PanelAccesoDirecto panelAccesoDirecto;
    public float psiquicRate;
    public float dobleRate;
    private float nextFire = 0.0f;
    public int velocidadX;
    public InventarioDhifeus inventarioDhifeus;
    public Image objetoArrastable;
    private SlotsObjetos SlotsObjetos;
    public OpcionesDhifeus opciones;
    public void Awake()
    {
        inventarioDhifeus.OnRightClickEvent += HabilidadEquipada;
        panelAccesoDirecto.OnRightClickEvent += HabilidadDesequipada;

        inventarioDhifeus.OnBeginDragEvent += BeginDrag;
        panelAccesoDirecto.OnBeginDragEvent += BeginDrag;

        inventarioDhifeus.OnEndDragEvent += EndDrag;
        panelAccesoDirecto.OnEndDragEvent += EndDrag;

        inventarioDhifeus.OnDragEvent += Drag;
        panelAccesoDirecto.OnDragEvent += Drag;

        inventarioDhifeus.OnDropEvent += Drop;
        panelAccesoDirecto.OnDropEvent += Drop;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && Time.time > nextFire)
        {
            if (Jugador.sprRenderer.flipX == true)
            {
                nextFire = Time.time + psiquicRate;
                balaPsiquica.CambiarDireccionBala(-velocidadX);
                sprBalaPsiquica.flipX = true;
                Psiquico();
            }
            else
            {
                sprBalaPsiquica.flipX = false;
                nextFire = Time.time + psiquicRate;
                balaPsiquica.CambiarDireccionBala(velocidadX);
                Psiquico();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFire)
        {
            if (Jugador.sprRenderer.flipX == true)
            {
                nextFire = Time.time + psiquicRate;
                balaDoble.CambiarDireccionBala(-velocidadX);
                sprBalaDoble.flipX = true;
                Doble();
            }
            else
            {
                sprBalaDoble.flipX = false;
                nextFire = Time.time + psiquicRate;
                balaDoble.CambiarDireccionBala(velocidadX);
                Doble();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && Time.time > nextFire)
        {
            if (Jugador.sprRenderer.flipX == true)
            {
                nextFire = Time.time + psiquicRate;
                balaAire.CambiarDireccionBala(-velocidadX);
                sprBalaAire.flipX = true;
                Aire();
            }
            else
            {
                sprBalaAire.flipX = false;
                nextFire = Time.time + psiquicRate;
                balaAire.CambiarDireccionBala(velocidadX);
                Aire();
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire)
        {
            if (Jugador.sprRenderer.flipX == true)
            {
                nextFire = Time.time + psiquicRate;
                balaFuego.CambiarDireccionBala(-velocidadX);
                sprBalaFuego.flipX = true;
                Fuego();
            }
            else
            {
                sprBalaFuego.flipX = false;
                nextFire = Time.time + psiquicRate;
                balaFuego.CambiarDireccionBala(velocidadX);
                Fuego();
            }
        }
        if (Salud <= 0)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            opciones.PerdisteEncendido = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigos"))
        {
            RecibirGolpe();
        }
    }
    public void RecibirGolpe()
    {
        Salud = Salud - 20;
        this.personaje.EstableciendoSalud(this.Salud, this.SaludMaxima);
        this.personaje.barraVida.value = Salud / SaludMaxima;
       

    }
    void Psiquico()
    {
        Instantiate(disparoPsiquico, transform.position, Quaternion.identity);
        estadisticasPersonaje.Mana = estadisticasPersonaje.Mana - 1;
        this.personaje.EstableciendoMana(this.Mana, this.ManaMaximo);
        this.personaje.barraMana.value = Mana / ManaMaximo;
    }
    void Doble()
    {
        Instantiate(disparoDoble, transform.position, Quaternion.identity);
        estadisticasPersonaje.Mana = estadisticasPersonaje.Mana - 5;
        this.personaje.EstableciendoMana(this.Mana, this.ManaMaximo);
        this.personaje.barraMana.value = Mana / ManaMaximo;
    }
    void Aire()
    {
        Instantiate(disparoAire, transform.position, Quaternion.identity);
        estadisticasPersonaje.Mana = estadisticasPersonaje.Mana - 3;
        this.personaje.EstableciendoMana(this.Mana, this.ManaMaximo);
        this.personaje.barraMana.value = Mana / ManaMaximo;
    }
    void Fuego()
    {
        Instantiate(disparoFuego, transform.position, Quaternion.identity);
        estadisticasPersonaje.Mana = estadisticasPersonaje.Mana - 2;
        this.personaje.EstableciendoMana(this.Mana, this.ManaMaximo);
        this.personaje.barraMana.value = Mana / ManaMaximo;
    }


    public void HabilidadEquipada(SlotsObjetos slotsObjetos)
    {
        HabilidadAAcceso habilidadAAcceso = slotsObjetos.Objeto as HabilidadAAcceso;
        if (habilidadAAcceso != null)
        {
            EquipoHabilidad(habilidadAAcceso);
        }
    }
    public void HabilidadDesequipada(SlotsObjetos slotsObjetos)
    {
        HabilidadAAcceso habilidadAAcceso = slotsObjetos.Objeto as HabilidadAAcceso;
        if (habilidadAAcceso != null)
        {
            SinEquiparHabilidad(habilidadAAcceso);
        }
    }
    public void EquipoHabilidad(HabilidadAAcceso objeto)
    {
        if (inventarioDhifeus.QuitarObjetos(objeto))
        {

            HabilidadAAcceso objetoAnterior;
            if (panelAccesoDirecto.AgregarHabilidad(objeto ,out objetoAnterior))
            {
                if (objetoAnterior != null)
                {
                    inventarioDhifeus.AgregarItem(objetoAnterior);
                }
            }
            else
            {
               inventarioDhifeus.AgregarItem(objeto);
            }
        }
    }
    public void SinEquiparHabilidad(HabilidadAAcceso objeto)
    {
        if (!inventarioDhifeus.estaLleno() && panelAccesoDirecto.QuitarHabilidad(objeto))
        {
            //habilidad.NoEquipo(this);
            inventarioDhifeus.AgregarItem(objeto);
            //habilidades.ActualizandoUIHabilidades();
        }
    }
    private void BeginDrag(SlotsObjetos slotsObjetos)
    {
        if (slotsObjetos.Objeto != null)
        {
            SlotsObjetos = slotsObjetos;
            objetoArrastable.sprite = slotsObjetos.Objeto.imagenObjeto;
            objetoArrastable.transform.position = Input.mousePosition;
            objetoArrastable.enabled = true;
        }
    }
    private void EndDrag(SlotsObjetos slotsObjetos)
    {
        SlotsObjetos = null;
        objetoArrastable.enabled = false;
    }
    private void Drag(SlotsObjetos slotsObjetos)
    {
        if (objetoArrastable.enabled)
        {
            objetoArrastable.transform.position = Input.mousePosition;
        }
    }
    private void Drop(SlotsObjetos dropSlotObjeto)
    {

        if (dropSlotObjeto.PuedeRecibirObjeto(SlotsObjetos.Objeto) && SlotsObjetos.PuedeRecibirObjeto(dropSlotObjeto.Objeto))
        {
            HabilidadAAcceso TomarItem = SlotsObjetos.Objeto as HabilidadAAcceso;
            HabilidadAAcceso SoltarItem = dropSlotObjeto.Objeto as HabilidadAAcceso;

            if (SlotsObjetos is SlotsAccesoDirecto)
            {
                if (TomarItem != null)
                {
                    TomarItem.NoEquipoAcceso(this);
                }
                if (SoltarItem != null)
                {
                    SoltarItem.SiEquipoAcceso(this);
                }
            }
            if (dropSlotObjeto is SlotsAccesoDirecto)
            {
                if (TomarItem != null)
                {
                    TomarItem.SiEquipoAcceso(this);
                }
                if (SoltarItem != null)
                {
                    SoltarItem.NoEquipoAcceso(this);
                }

            }
            
            Objetos objetoArrastable = SlotsObjetos.Objeto;
            SlotsObjetos.Objeto = dropSlotObjeto.Objeto;
            dropSlotObjeto.Objeto = objetoArrastable;
        }
    }
}
