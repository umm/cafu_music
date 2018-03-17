# CAFU Music

## What

* BGM を再生するための UseCase を提供します

## Requirement

* CAFU Core v2.0.0

## Install

```shell
npm install github:umm-projects/cafu_music
```

## Usage

### スクリプト準備編

#### 1. BGM の AudioClip を表現する enum を定義

```csharp
public static class Enumerates {
    public enum MusicName {
        Title,
        Menu,
        Game,
    }
}
```

#### 2. `CAFU.Music.Data.Entity.MusicEntity<TEnum>` を継承した Entity クラスを作成

```csharp
using System;
using CAFU.Music.Data.Entity;
namespace SampleProject.Data.Entity {
    [Serializable]
    public class MusicEntity : MusicEntity<MusicName> {}
}
```

* Unity の仕様により Generic クラスを Serialize できないため、プロジェクトごとに継承する必要があります😢

#### 3. `CAFU.Music.Data.DataStore.MusicDataStore***<TMusicEntity>` を継承した DataStore クラスを作成

* Unity の仕様により Generic クラスを Serialize できないため、プロジェクトごとに継承する必要があります😢

##### シーン内で単一の BGM を再生する場合

```csharp
using CAFU.Music.Data.DataStore;
using SampleProject.Data.Entity;
namespace SampleProject.Data.DataStore {
    public class MusicDataStore : MusicDataStoreSingle<MusicEntity> {}
}
```

##### シーン内で複数の BGM を切り替えて再生する場合

```csharp
using CAFU.Music.Data.DataStore;
using SampleProject.Data.Entity;
namespace SampleProject.Data.DataStore {
    public class MusicDataStore : MusicDataStoreMultiple<MusicEntity> {}
}
```

### シーン準備編

#### 1. `CAFU.Music.Presentation.Presenter.IMusicPresenter` を Presenter クラスに実装

```csharp
using CAFU.Core.Presentation.Presenter;
using CAFU.Music.Presentation.Presenter;
namespace SampleProject.Presentation.Presenter {
    public class SampleScenePresenter : IPresenter, IMusicPresenter {
        public class Factory : DefaultPresenterFactory<SampleScenePresenter> {
            protected override void Initialize(SampleScenePresenter instance) {
                base.Initialize(instance);
                instance.MusicUseCase = new MusicUseCase<MusicName>.Factory().Create();
            }
        }
        public IMusicUseCase MusicUseCase { get; private set; }
    }
}
```

* 拡張メソッドから利用するため、 `MusicUseCase` のプロパティ定義が必須です。

#### 2. Scene の任意の GameObject に `MusicDataStore` をアタッチ

* Hierarchy ルートの `DataStore` とかがヨサソウです。
* ![image](https://user-images.githubusercontent.com/838945/37551295-8ef4ebb0-29e0-11e8-9b52-41969b144be8.png)
* ![image](https://user-images.githubusercontent.com/838945/37551342-51303c66-29e1-11e8-9624-f63efff6c0fb.png)

#### 3. アタッチされている `Controller` の *Music Data Store* フィールドに 2. の GameObject を D&amp;D

* これにより、実行順制御が可能になります。

#### 4. Scene で用いる BGM を `MusicDataStore` のフィールドに設定

* ![image](https://user-images.githubusercontent.com/838945/37551293-7ab19838-29e0-11e8-8447-1a1f724b1d34.png)

### 利用編

#### 再生

```csharp
this.GetPresenter().PlayMusic(MusicName.Title, true, true);
```

##### 引数

1. 再生する BGM を表す enum
1. ループするかどうか (default: `true`)
1. 既に同一の BGM が再生中の場合は、再生を止めずにそのままキープするかどうか (default: `true`)

#### 停止

```csharp
this.GetPresenter().Stop();
```

#### 中断

```csharp
this.GetPresenter().Pause();
```

#### 再開

```csharp
this.GetPresenter().Resume();
```

#### ボリューム操作

```csharp
this.GetPresenter().SetVolume(0.5f);
```

## License

Copyright (c) 2018 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)
