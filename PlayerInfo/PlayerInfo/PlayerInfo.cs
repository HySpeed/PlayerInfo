using Hooks;
using TShockAPI;
using System.IO;
using System;
using Terraria;

// PlayerInfo ******************************************************************
namespace PlayerInfo
{

  // PlayerInfo ****************************************************************
  [APIVersion(1, 11)]
  public class PlayerInfo : TerrariaPlugin
  {
    

    #region Plugin Overrides
    // Initialize ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public override void Initialize()
    {
      ServerHooks.Join  += OnJoin;
      Commands.Init();
    } // Initialize ------------------------------------------------------------

    
    // Dispose +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void Dispose( bool disposing )
    {
      if ( disposing )
      {
        ServerHooks.Join -= OnJoin;
        base.Dispose( disposing );
      } // if
    } // Dispose ---------------------------------------------------------------
    #endregion // Plugin Overrides _____________________________________________


    #region Plugin Hooks 
    // OnJoin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void OnJoin( int player, 
                 System.ComponentModel.HandledEventArgs eventArgs )
    {
      if ( !eventArgs.Handled ) 
      {
        // string.Format causes this to hang
        TShock.Utils.Broadcast( "Joining: " + Main.player[player].name + 
                                "(" + Main.player[player].statLifeMax.ToString() + 
                                "/" + Main.player[player].statManaMax.ToString() + ")", Color.Azure );
      } // if

    } // OnJoin ----------------------------------------------------------------

    
    // OnError +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public static void OnError( object         sender, 
                                ErrorEventArgs error )
    {
      Log.Error( "! PlayerInfo Error: " + error.ToString() );
    } // OnError ---------------------------------------------------------------
    #endregion // Plugin Hooks _________________________________________________


    #region Plugin Properties
    // Name ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public override string Name
    {
      get { return "PlayerInfo"; }
    } // Name ------------------------------------------------------------------


    // Author ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public override string Author
    {
      get { return "_Jon"; }
    } // Author ----------------------------------------------------------------


    // Description +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public override string Description
    {
      get { return "Provides player from commands (/pInfo)"; }
    } // Description -----------------------------------------------------------


    // Version +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
   public override Version Version
    {
      get { return new Version( 1, 0, 1, 3 ); }
    } // Versin ----------------------------------------------------------------

    
    // PlayerInfo **************************************************************
    public PlayerInfo( Main game ) : base( game )
    {
      Order = 11;
    } // PlayerInfo ------------------------------------------------------------
    #endregion // Plugin Properties ____________________________________________


  } // PlayerInfo ==============================================================


} // PlayerInfo ================================================================
