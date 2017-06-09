<root dataType="Struct" type="Duality.Resources.Prefab" id="129723834">
  <assetInfo dataType="Struct" type="Duality.Editor.AssetManagement.AssetInfo" id="427169525">
    <customData />
    <importerId />
    <sourceFileHint />
  </assetInfo>
  <objTree dataType="Struct" type="Duality.GameObject" id="3139134703">
    <active dataType="Bool">true</active>
    <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="327559316">
      <_items dataType="Array" type="Duality.GameObject[]" id="2484430692">
        <item dataType="Struct" type="Duality.GameObject" id="3171582143">
          <active dataType="Bool">true</active>
          <children />
          <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="609920419">
            <_items dataType="Array" type="Duality.Component[]" id="3743438694" length="4">
              <item dataType="Struct" type="Duality.Components.Transform" id="1236929779">
                <active dataType="Bool">true</active>
                <angle dataType="Float">0</angle>
                <angleAbs dataType="Float">0</angleAbs>
                <angleVel dataType="Float">0</angleVel>
                <angleVelAbs dataType="Float">0</angleVelAbs>
                <deriveAngle dataType="Bool">true</deriveAngle>
                <gameobj dataType="ObjectRef">3171582143</gameobj>
                <ignoreParent dataType="Bool">false</ignoreParent>
                <parentTransform dataType="Struct" type="Duality.Components.Transform" id="1204482339">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <angleVel dataType="Float">0</angleVel>
                  <angleVelAbs dataType="Float">0</angleVelAbs>
                  <deriveAngle dataType="Bool">true</deriveAngle>
                  <gameobj dataType="ObjectRef">3139134703</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <parentTransform />
                  <pos dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">-254</X>
                    <Y dataType="Float">-95.5</Y>
                    <Z dataType="Float">0</Z>
                  </pos>
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">-254</X>
                    <Y dataType="Float">-95.5</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                  <vel dataType="Struct" type="Duality.Vector3" />
                  <velAbs dataType="Struct" type="Duality.Vector3" />
                </parentTransform>
                <pos dataType="Struct" type="Duality.Vector3" />
                <posAbs dataType="Struct" type="Duality.Vector3">
                  <X dataType="Float">-254</X>
                  <Y dataType="Float">-95.5</Y>
                  <Z dataType="Float">0</Z>
                </posAbs>
                <scale dataType="Float">1</scale>
                <scaleAbs dataType="Float">1</scaleAbs>
                <vel dataType="Struct" type="Duality.Vector3" />
                <velAbs dataType="Struct" type="Duality.Vector3" />
              </item>
              <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="878466864">
                <active dataType="Bool">true</active>
                <gameobj dataType="ObjectRef">3171582143</gameobj>
                <tileData dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapData" id="1032473676" custom="true">
                  <body>
                    <version dataType="Int">3</version>
                    <data dataType="Array" type="System.Byte[]" id="3410083748">H4sIAAAAAAAEAO3FsQ0AMAgEsR+COiX7jwjKCrQ+6eSXpPbODwAAAAAA4MwASpklB3AQAAA=</data>
                  </body>
                </tileData>
                <tileset dataType="Struct" type="Duality.ContentRef`1[[Duality.Plugins.Tilemaps.Tileset]]">
                  <contentPath dataType="String">Data\tileset.Tileset.res</contentPath>
                </tileset>
              </item>
              <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="1869690295">
                <active dataType="Bool">true</active>
                <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                  <A dataType="Byte">255</A>
                  <B dataType="Byte">255</B>
                  <G dataType="Byte">255</G>
                  <R dataType="Byte">255</R>
                </colorTint>
                <externalTilemap />
                <gameobj dataType="ObjectRef">3171582143</gameobj>
                <offset dataType="Float">0</offset>
                <origin dataType="Enum" type="Duality.Alignment" name="TopLeft" value="5" />
                <tileDepthMode dataType="Enum" type="Duality.Plugins.Tilemaps.TileDepthOffsetMode" name="Flat" value="0" />
                <tileDepthOffset dataType="Int">0</tileDepthOffset>
                <tileDepthScale dataType="Float">0.01</tileDepthScale>
                <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
              </item>
            </_items>
            <_size dataType="Int">3</_size>
          </compList>
          <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="139423608" surrogate="true">
            <header />
            <body>
              <keys dataType="Array" type="System.Object[]" id="3306823369">
                <item dataType="Type" id="3556863630" value="Duality.Components.Transform" />
                <item dataType="Type" id="276721738" value="Duality.Plugins.Tilemaps.Tilemap" />
                <item dataType="Type" id="2744573374" value="Duality.Plugins.Tilemaps.TilemapRenderer" />
              </keys>
              <values dataType="Array" type="System.Object[]" id="2239285824">
                <item dataType="ObjectRef">1236929779</item>
                <item dataType="ObjectRef">878466864</item>
                <item dataType="ObjectRef">1869690295</item>
              </values>
            </body>
          </compMap>
          <compTransform dataType="ObjectRef">1236929779</compTransform>
          <identifier dataType="Struct" type="System.Guid" surrogate="true">
            <header>
              <data dataType="Array" type="System.Byte[]" id="423056107">Y8t2dXzR4ku7PBlAT2yKPg==</data>
            </header>
            <body />
          </identifier>
          <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
          <name dataType="String">[1] Layer1</name>
          <parent dataType="ObjectRef">3139134703</parent>
          <prefabLink />
        </item>
        <item dataType="Struct" type="Duality.GameObject" id="4259186098">
          <active dataType="Bool">true</active>
          <children />
          <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2707649058">
            <_items dataType="Array" type="Duality.Component[]" id="2764793104" length="4">
              <item dataType="Struct" type="Duality.Components.Transform" id="2324533734">
                <active dataType="Bool">true</active>
                <angle dataType="Float">0</angle>
                <angleAbs dataType="Float">0</angleAbs>
                <angleVel dataType="Float">0</angleVel>
                <angleVelAbs dataType="Float">0</angleVelAbs>
                <deriveAngle dataType="Bool">true</deriveAngle>
                <gameobj dataType="ObjectRef">4259186098</gameobj>
                <ignoreParent dataType="Bool">false</ignoreParent>
                <parentTransform dataType="ObjectRef">1204482339</parentTransform>
                <pos dataType="Struct" type="Duality.Vector3" />
                <posAbs dataType="Struct" type="Duality.Vector3">
                  <X dataType="Float">-254</X>
                  <Y dataType="Float">-95.5</Y>
                  <Z dataType="Float">0</Z>
                </posAbs>
                <scale dataType="Float">1</scale>
                <scaleAbs dataType="Float">1</scaleAbs>
                <vel dataType="Struct" type="Duality.Vector3" />
                <velAbs dataType="Struct" type="Duality.Vector3" />
              </item>
              <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="1966070819">
                <active dataType="Bool">true</active>
                <gameobj dataType="ObjectRef">4259186098</gameobj>
                <tileData dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapData" id="1814324599" custom="true">
                  <body>
                    <version dataType="Int">3</version>
                    <data dataType="Array" type="System.Byte[]" id="3282487182">H4sIAAAAAAAEAJNjYGAQYRgFgxNwE62SiYauoBcg3re0AAMbgvj8rgmhtOjikFEwSMFoKhiGgORIJb6UIsLo4VBpjALSweCN98HrsqEJBrZJNXjBUElndKv0ibdoUATdaLoeogAAOhHtL3AQAAA=</data>
                  </body>
                </tileData>
                <tileset dataType="Struct" type="Duality.ContentRef`1[[Duality.Plugins.Tilemaps.Tileset]]">
                  <contentPath dataType="String">Data\tileset.Tileset.res</contentPath>
                </tileset>
              </item>
              <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="2957294250">
                <active dataType="Bool">true</active>
                <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                  <A dataType="Byte">255</A>
                  <B dataType="Byte">255</B>
                  <G dataType="Byte">255</G>
                  <R dataType="Byte">255</R>
                </colorTint>
                <externalTilemap />
                <gameobj dataType="ObjectRef">4259186098</gameobj>
                <offset dataType="Float">0</offset>
                <origin dataType="Enum" type="Duality.Alignment" name="TopLeft" value="5" />
                <tileDepthMode dataType="Enum" type="Duality.Plugins.Tilemaps.TileDepthOffsetMode" name="Flat" value="0" />
                <tileDepthOffset dataType="Int">0</tileDepthOffset>
                <tileDepthScale dataType="Float">0.01</tileDepthScale>
                <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
              </item>
            </_items>
            <_size dataType="Int">3</_size>
          </compList>
          <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3020233994" surrogate="true">
            <header />
            <body>
              <keys dataType="Array" type="System.Object[]" id="1364989880">
                <item dataType="ObjectRef">3556863630</item>
                <item dataType="ObjectRef">276721738</item>
                <item dataType="ObjectRef">2744573374</item>
              </keys>
              <values dataType="Array" type="System.Object[]" id="2387007710">
                <item dataType="ObjectRef">2324533734</item>
                <item dataType="ObjectRef">1966070819</item>
                <item dataType="ObjectRef">2957294250</item>
              </values>
            </body>
          </compMap>
          <compTransform dataType="ObjectRef">2324533734</compTransform>
          <identifier dataType="Struct" type="System.Guid" surrogate="true">
            <header>
              <data dataType="Array" type="System.Byte[]" id="2070789604">bEgBrt+EB02rINeXQmRL2Q==</data>
            </header>
            <body />
          </identifier>
          <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
          <name dataType="String">[2] Layer2</name>
          <parent dataType="ObjectRef">3139134703</parent>
          <prefabLink />
        </item>
        <item dataType="Struct" type="Duality.GameObject" id="3286266177">
          <active dataType="Bool">true</active>
          <children />
          <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1861613661">
            <_items dataType="Array" type="Duality.Component[]" id="1136391014" length="4">
              <item dataType="Struct" type="Duality.Components.Transform" id="1351613813">
                <active dataType="Bool">true</active>
                <angle dataType="Float">0</angle>
                <angleAbs dataType="Float">0</angleAbs>
                <angleVel dataType="Float">0</angleVel>
                <angleVelAbs dataType="Float">0</angleVelAbs>
                <deriveAngle dataType="Bool">true</deriveAngle>
                <gameobj dataType="ObjectRef">3286266177</gameobj>
                <ignoreParent dataType="Bool">false</ignoreParent>
                <parentTransform dataType="ObjectRef">1204482339</parentTransform>
                <pos dataType="Struct" type="Duality.Vector3" />
                <posAbs dataType="Struct" type="Duality.Vector3">
                  <X dataType="Float">-254</X>
                  <Y dataType="Float">-95.5</Y>
                  <Z dataType="Float">0</Z>
                </posAbs>
                <scale dataType="Float">1</scale>
                <scaleAbs dataType="Float">1</scaleAbs>
                <vel dataType="Struct" type="Duality.Vector3" />
                <velAbs dataType="Struct" type="Duality.Vector3" />
              </item>
            </_items>
            <_size dataType="Int">1</_size>
          </compList>
          <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1478499192" surrogate="true">
            <header />
            <body>
              <keys dataType="Array" type="System.Object[]" id="3712107319">
                <item dataType="ObjectRef">3556863630</item>
              </keys>
              <values dataType="Array" type="System.Object[]" id="3647229504">
                <item dataType="ObjectRef">1351613813</item>
              </values>
            </body>
          </compMap>
          <compTransform dataType="ObjectRef">1351613813</compTransform>
          <identifier dataType="Struct" type="System.Guid" surrogate="true">
            <header>
              <data dataType="Array" type="System.Byte[]" id="1270003477">zT+7AFvnok6kDiQFGzdfLg==</data>
            </header>
            <body />
          </identifier>
          <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
          <name dataType="String">[3] Objects</name>
          <parent dataType="ObjectRef">3139134703</parent>
          <prefabLink />
        </item>
        <item dataType="Struct" type="Duality.GameObject" id="1148107551">
          <active dataType="Bool">true</active>
          <children />
          <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="508356675">
            <_items dataType="Array" type="Duality.Component[]" id="1314896934" length="4">
              <item dataType="Struct" type="Duality.Components.Transform" id="3508422483">
                <active dataType="Bool">true</active>
                <angle dataType="Float">0</angle>
                <angleAbs dataType="Float">0</angleAbs>
                <angleVel dataType="Float">0</angleVel>
                <angleVelAbs dataType="Float">0</angleVelAbs>
                <deriveAngle dataType="Bool">true</deriveAngle>
                <gameobj dataType="ObjectRef">1148107551</gameobj>
                <ignoreParent dataType="Bool">false</ignoreParent>
                <parentTransform dataType="ObjectRef">1204482339</parentTransform>
                <pos dataType="Struct" type="Duality.Vector3" />
                <posAbs dataType="Struct" type="Duality.Vector3">
                  <X dataType="Float">-254</X>
                  <Y dataType="Float">-95.5</Y>
                  <Z dataType="Float">0</Z>
                </posAbs>
                <scale dataType="Float">1</scale>
                <scaleAbs dataType="Float">1</scaleAbs>
                <vel dataType="Struct" type="Duality.Vector3" />
                <velAbs dataType="Struct" type="Duality.Vector3" />
              </item>
              <item dataType="Struct" type="Duality.Plugins.Tilemaps.Tilemap" id="3149959568">
                <active dataType="Bool">true</active>
                <gameobj dataType="ObjectRef">1148107551</gameobj>
                <tileData dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapData" id="1766803500" custom="true">
                  <body>
                    <version dataType="Int">3</version>
                    <data dataType="Array" type="System.Byte[]" id="680488164">H4sIAAAAAAAEAO2VOw6AMAxDs/EZ+YwU7n/KDu5eIRKHSn7LGxMprlvM7DDRYYJmaIHWnF182KAdahE4c3bx4YIKdEOP5wSl4P+8TkHgUZPyEnjUpLwEPu341hBCDAutxGmDaCVOG0Qrcf0WQnygAiLT/rdwEAAA</data>
                  </body>
                </tileData>
                <tileset dataType="Struct" type="Duality.ContentRef`1[[Duality.Plugins.Tilemaps.Tileset]]">
                  <contentPath dataType="String">Data\tileset.Tileset.res</contentPath>
                </tileset>
              </item>
              <item dataType="Struct" type="Duality.Plugins.Tilemaps.TilemapRenderer" id="4141182999">
                <active dataType="Bool">true</active>
                <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                  <A dataType="Byte">255</A>
                  <B dataType="Byte">255</B>
                  <G dataType="Byte">255</G>
                  <R dataType="Byte">255</R>
                </colorTint>
                <externalTilemap />
                <gameobj dataType="ObjectRef">1148107551</gameobj>
                <offset dataType="Float">0</offset>
                <origin dataType="Enum" type="Duality.Alignment" name="TopLeft" value="5" />
                <tileDepthMode dataType="Enum" type="Duality.Plugins.Tilemaps.TileDepthOffsetMode" name="Flat" value="0" />
                <tileDepthOffset dataType="Int">0</tileDepthOffset>
                <tileDepthScale dataType="Float">0.01</tileDepthScale>
                <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
              </item>
            </_items>
            <_size dataType="Int">3</_size>
          </compList>
          <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1621257912" surrogate="true">
            <header />
            <body>
              <keys dataType="Array" type="System.Object[]" id="2618472233">
                <item dataType="ObjectRef">3556863630</item>
                <item dataType="ObjectRef">276721738</item>
                <item dataType="ObjectRef">2744573374</item>
              </keys>
              <values dataType="Array" type="System.Object[]" id="2451066304">
                <item dataType="ObjectRef">3508422483</item>
                <item dataType="ObjectRef">3149959568</item>
                <item dataType="ObjectRef">4141182999</item>
              </values>
            </body>
          </compMap>
          <compTransform dataType="ObjectRef">3508422483</compTransform>
          <identifier dataType="Struct" type="System.Guid" surrogate="true">
            <header>
              <data dataType="Array" type="System.Byte[]" id="2058081547">9v/v4YENxES9tqj8EE3bLQ==</data>
            </header>
            <body />
          </identifier>
          <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
          <name dataType="String">[4] Layer3</name>
          <parent dataType="ObjectRef">3139134703</parent>
          <prefabLink />
        </item>
      </_items>
      <_size dataType="Int">4</_size>
    </children>
    <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="182928438">
      <_items dataType="Array" type="Duality.Component[]" id="1423207742" length="4">
        <item dataType="ObjectRef">1204482339</item>
      </_items>
      <_size dataType="Int">1</_size>
    </compList>
    <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="919728432" surrogate="true">
      <header />
      <body>
        <keys dataType="Array" type="System.Object[]" id="3035230664">
          <item dataType="ObjectRef">3556863630</item>
        </keys>
        <values dataType="Array" type="System.Object[]" id="3853151966">
          <item dataType="ObjectRef">1204482339</item>
        </values>
      </body>
    </compMap>
    <compTransform dataType="ObjectRef">1204482339</compTransform>
    <identifier dataType="Struct" type="System.Guid" surrogate="true">
      <header>
        <data dataType="Array" type="System.Byte[]" id="995248180">riIl+D4clEanb19rEg4b1Q==</data>
      </header>
      <body />
    </identifier>
    <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
    <name dataType="String">testmap</name>
    <parent />
    <prefabLink />
  </objTree>
</root>
<!-- XmlFormatterBase Document Separator -->
