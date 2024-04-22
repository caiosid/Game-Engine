namespace Project002;

public class GameManager
{
    private readonly Player _player;
    private readonly Background _bg;
    private SpriteFont fonte;

    private bool acabou;
    private bool creditos;

    private int tempoFinalizacao;
    private int TempoParaCredito;

    public GameManager()
    {
        _bg = new();
        var texture = Globals.Content.Load<Texture2D>("bullet");
        ProjectileManager.Init(texture);
        UIManager.Init(texture);
        ExperienceManager.Init(Globals.Content.Load<Texture2D>("exp"));

        _player = new(Globals.Content.Load<Texture2D>("player"));
        ZombieManager.Init();
        fonte = Globals.Content.Load<SpriteFont>("font");
        acabou = false;
        creditos = false;
    }

    public void Restart()
    {
        ProjectileManager.Reset();
        ZombieManager.Reset();
        ExperienceManager.Reset();
        _player.Reset();
        acabou = false;
        creditos = false;
    }

    public void Update()
    {
        /*InputManager.Update();
        ExperienceManager.Update(_player);
        _player.Update(ZombieManager.Zombies);
        ZombieManager.Update(_player);
        ProjectileManager.Update(ZombieManager.Zombies);*/

        if (!_player.Dead){
            InputManager.Update();
            ExperienceManager.Update(_player);
            _player.Update(ZombieManager.Zombies);
            ZombieManager.Update(_player);
            ProjectileManager.Update(ZombieManager.Zombies);
        }else{

            if(!acabou){
                tempoFinalizacao = TempoParaCredito + 100;
                acabou = true;
                TempoParaCredito = 0;
            }
            TempoParaCredito++;
            if(acabou && TempoParaCredito > tempoFinalizacao){
                creditos = true;
            }

        }

        //if (_player.Dead) Restart();
    }

    public void Draw()
    {
        if(!creditos){
        _bg.Draw();
        ExperienceManager.Draw();
        ProjectileManager.Draw();
        _player.Draw();
        ZombieManager.Draw();
        UIManager.Draw(_player);
        if(acabou){
            Globals.SpriteBatch.DrawString(fonte, "Lascousse! Fim de Jogo!", new Vector2((Globals.Bounds.X / 3) , (Globals.Bounds.Y / 2)), Color.Red);
        }
        }else{
            
                Globals.SpriteBatch.DrawString(fonte, "Creditos = \nAtividade Game Engine: \nAlunos: \nJoao Ricardo Agostinho \nRamon Chaves"+
                "\nCaio Barbosa \nVictor Lima \nPedro Castro \nCarlos Cunha", new Vector2(0 , 0), Color.Red);
            
        }
    }
}
