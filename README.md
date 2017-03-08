# Unity Pooling Manager
> Simple pooling manager for Unity3D.


Simple singleton pooling manager implementation. It manages pooled gameObjects by name and can also spawn them by name. Simply attach the PoolingManager script to an empty gameObject. Objects that you wish to use in the PoolManager must be put into a subfolder in the Resources folders (Ex. Resources/Enemies). You will need to put the names of the subfolders in the PoolingManager's inspector variable "Resource Name" array. The ObjectToPool script should be attached to any gameObject you wish to pool. It will add the gameObject to the pool when it gets disabled. 

## Installation

Requires Unity3D


## Usage example

To spawn a penguin monster from your pool you would simple use the following functions.
```sh
PoolingManager.Instance.Instantiate("Penguin", Vector3.zero, Quaternion.identity);
```

## Meta

Ut Duong – [twitter@TheUtDuong](https://twitter.com/TheUtDuong) – ut@utduong.com

Distributed under the GPL3.0 license. See ``LICENSE`` for more information.

[https://github.com/TheUtDuong](https://github.com/TheUtDuong)

[npm-image]: https://img.shields.io/npm/v/datadog-metrics.svg?style=flat-square
[npm-url]: https://npmjs.org/package/datadog-metrics
[npm-downloads]: https://img.shields.io/npm/dm/datadog-metrics.svg?style=flat-square
