using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TestMonoGame.Scripts;
namespace TestMonoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private List<IUpdatableItem> _updateables;
    private List<RenderItem> _renderQueue;
    private bool _isLoading;
    

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
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
    }

    internal void AddUpdatable(IUpdatableItem updatableItem)
    {
        if (_updateables.Contains(updatableItem)) return;
        _updateables.Add(updatableItem);
    }
    private void RemoveUpdatable(IUpdatableItem updatableItem)
    {
        if (!_updateables.Contains(updatableItem)) return;
        _updateables.Remove(updatableItem);
    }
    internal void AddToRenderQueue(RenderItem render)
    {
        if (_renderQueue.Contains(render)) return;
        _renderQueue.Add(render);
    }
    private void RemoveRender(RenderItem render)
    {
        if (!_renderQueue.Contains(render)) return;
        _renderQueue.Add(render);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        LoadSystem.Load(Content);
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
        if()
        if(_renderQueue.Count > 0)
        {
            _spriteBatch.Begin();
            for(int i = 0; i < _renderQueue.Count; i++)
            {
                RenderItem r = _renderQueue[i];
                _spriteBatch.Draw(r.Texture, r.Position, r.Rectangle, 
                    r.Color, r.Rotation,r.RotationOrigin, new Vector2(1,1),SpriteEffects.None, 0f);
            }
            _spriteBatch.End();
        }

        base.Draw(gameTime);
    }

}