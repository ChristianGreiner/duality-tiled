<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="1295064867">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3392067345">
        <_items dataType="Array" type="Duality.Component[]" id="2526995182" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3655379799">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">1295064867</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="1832340674">
            <active dataType="Bool">true</active>
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">1295064867</gameobj>
            <nearZ dataType="Float">0</nearZ>
            <passes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Camera+Pass]]" id="1561582470">
              <_items dataType="Array" type="Duality.Components.Camera+Pass[]" id="1846500224" length="4">
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="3839177116">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="All" value="3" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="PerspectiveWorld" value="0" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
                </item>
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="313442326">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="None" value="0" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="OrthoScreen" value="1" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </passes>
            <perspective dataType="Enum" type="Duality.Drawing.PerspectiveMode" name="Parallax" value="1" />
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="1948546238">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1295064867</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4063884192" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3304424123">
            <item dataType="Type" id="1578653910" value="Duality.Components.Transform" />
            <item dataType="Type" id="1737591770" value="Duality.Components.Camera" />
            <item dataType="Type" id="1533886966" value="Duality.Components.SoundListener" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3875916840">
            <item dataType="ObjectRef">3655379799</item>
            <item dataType="ObjectRef">1832340674</item>
            <item dataType="ObjectRef">1948546238</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3655379799</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1221296945">MlbmPtc8rEm9Ck9fgkwPvQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">MainCamera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="4039716146">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="3409838300">
        <_items dataType="Array" type="Duality.GameObject[]" id="342768324">
          <item dataType="Struct" type="Duality.GameObject" id="4043038651">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1841328279">
              <_items dataType="Array" type="Duality.Component[]" id="1077193998" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="2108386287">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">4043038651</gameobj>
                </item>
                <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="1749923372">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">4043038651</gameobj>
                </item>
                <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="2741146803">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">4043038651</gameobj>
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1071583936" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="3908162589">
                  <item dataType="ObjectRef">1578653910</item>
                  <item dataType="Type" id="604068070" value="Duality.Plugins.Tilemaps.Tilemap" />
                  <item dataType="Type" id="1817880890" value="Duality.Plugins.Tilemaps.TilemapRenderer" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="4113467128">
                  <item dataType="ObjectRef">2108386287</item>
                  <item dataType="ObjectRef">1749923372</item>
                  <item dataType="ObjectRef">2741146803</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">2108386287</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="4174201015">VZ7I5DN0l0GG8WBicOXUeQ==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">[1] Layer1</name>
            <parent dataType="ObjectRef">4039716146</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="1999847355">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="675254423">
              <_items dataType="Array" type="Duality.Component[]" id="39038222" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="65194991">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1999847355</gameobj>
                </item>
                <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="4001699372">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1999847355</gameobj>
                </item>
                <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="697955507">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1999847355</gameobj>
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4203877056" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="804992029">
                  <item dataType="ObjectRef">1578653910</item>
                  <item dataType="ObjectRef">604068070</item>
                  <item dataType="ObjectRef">1817880890</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="4118415096">
                  <item dataType="ObjectRef">65194991</item>
                  <item dataType="ObjectRef">4001699372</item>
                  <item dataType="ObjectRef">697955507</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">65194991</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="11165879">+XViClFWUkqP/yt05txLEA==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">[2] Layer2</name>
            <parent dataType="ObjectRef">4039716146</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="2907506721">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3918886781">
              <_items dataType="Array" type="Duality.Component[]" id="2865199910" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="972854357">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">2907506721</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1260307896" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1314617367">
                  <item dataType="ObjectRef">1578653910</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="4083544256">
                  <item dataType="ObjectRef">972854357</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">972854357</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="805802421">YETcpJHsV0yN1uV0zj/VFg==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">[3] Objects</name>
            <parent dataType="ObjectRef">4039716146</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="3967089267">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1147203615">
              <_items dataType="Array" type="Duality.Component[]" id="1107622254" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="2032436903">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">3967089267</gameobj>
                </item>
                <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="1673973988">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">3967089267</gameobj>
                </item>
                <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="2665197419">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">3967089267</gameobj>
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="402083872" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1112985493">
                  <item dataType="ObjectRef">1578653910</item>
                  <item dataType="ObjectRef">604068070</item>
                  <item dataType="ObjectRef">1817880890</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="3141032136">
                  <item dataType="ObjectRef">2032436903</item>
                  <item dataType="ObjectRef">1673973988</item>
                  <item dataType="ObjectRef">2665197419</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">2032436903</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2842570399">9LhSlya8G0KDFscfm+QpnA==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">[4] Layer3</name>
            <parent dataType="ObjectRef">4039716146</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="242403606">
        <_items dataType="Array" type="Duality.Component[]" id="4056304118" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2105063782">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">4039716146</gameobj>
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="153580104" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="603747480">
            <item dataType="ObjectRef">1578653910</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="4191253790">
            <item dataType="ObjectRef">2105063782</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2105063782</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1814671044">IW2BVkj4b0CBSF5dNfBRfA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">testmap</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="1523160498">
        <changes />
        <obj dataType="ObjectRef">4039716146</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\testmap.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="ObjectRef">3967089267</item>
    <item dataType="ObjectRef">2907506721</item>
    <item dataType="ObjectRef">1999847355</item>
    <item dataType="ObjectRef">4043038651</item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
