using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TestMonoGame.Scripts;
namespace TestMonoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private List<IUpdatableItem> _updateables;
    private List<RenderItem> _renderQueue;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        SystemInitialize();
        InstantiateItems();

        base.Initialize();
    }

    private void InstantiateItems()
    {
        PlayerFabric playerFabric = new PlayerFabric();
        InputManager inputManager = new InputManager();
     
        PlayerController controller = playerFabric.Create(inputManager, this);
        AddUpdatable(controller);
        AddUpdatable(inputManager);
    }

    private void SystemInitialize()
    {
        _updateables = new List<IUpdatableItem>();
        _renderQueue = new List<RenderItem>();
        _graphics.PreferredBackBufferWidth = 1000;
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
    }

    internal void AddUpdatable(IUpdatableItem updatableItem)
    {
        if (_updateables.Contains(updatableItem)) return;
        _updateables.Add(updatableItem);
    }
    internal void RemoveUpdatable(IUpdatableItem updatableItem)
    {
        if (!_updateables.Contains(updatableItem)) return;
        _updateables.Remove(updatableItem);
    }
    internal void AddToRenderQueue(RenderItem render)
    {
        if (_renderQueue.Contains(render)) return;
        _renderQueue.Add(render);
    }
    internal void RemoveRender(RenderItem render)
    {
        if (!_renderQueue.Contains(render)) return;
        _renderQueue.Add(render);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        OnLoad();
    }

    private async void OnLoad()
    {
       await LoadSystem.Load(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        CheckInputs();
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_updateables.Count > 0)
        {
            for (int i = 0; i < _updateables.Count; i++)
            {
                _updateables[i].OnUpdate(deltaTime);
            }
        }


        base.Update(gameTime);
    }

    private void CheckInputs()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))Exit();
    }

    protected override void Draw(GameTime gameTime)
    {
        
        GraphicsDevice.Clear(Color.Black);
        if(_renderQueue.Count > 0)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            for(int i = 0; i < _renderQueue.Count; i++)
            {
                RenderItem r = _renderQueue[i];
               
                if (r.Texture == null)continue;
              
                _spriteBatch.Draw(r.Texture, r.GetPosition(), r.Rectangle, 
                    r.Color, r.GetRotation(), 
                    r.GetOrigin, 
                    r.Scale,r.Flip.Item1 | r.Flip.Item2, 0f);

               /* Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.Red });

                _spriteBatch.Draw(
                    pixel,
                    r.GetOrigin,
                    null,
                    Color.White,
                    0f,
                    Vector2.One * 0.5f,
                    5f,  // Размер точки
                    SpriteEffects.None,
                    0f
                );*/
            }
            _spriteBatch.End();
        }

        base.Draw(gameTime);
    }

}